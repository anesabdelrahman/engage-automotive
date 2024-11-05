using System.Net;
using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace AutomotivePartsOrdering.Tests.Services;

[TestFixture(Category = "Services")]
public class BrandServiceTests {
    private Mock<IHttpClientWrapper> _httpClientWrapperMock;
    private Mock<IAuthorisationService> _authorisationServiceMock;
    private Mock<IOptions<ProviderSettings>> _optionsMock;
    private Mock<ILogger<BrandService>> _loggerMock;
    private ProviderSettings _providerSettings;

    private BrandService _brandService;

    [SetUp]
    public void Setup() {
        _httpClientWrapperMock = new Mock<IHttpClientWrapper>();
        _authorisationServiceMock = new Mock<IAuthorisationService>();
        _optionsMock = new Mock<IOptions<ProviderSettings>>();
        _loggerMock = new Mock<ILogger<BrandService>>();

        _providerSettings = new ProviderSettings {
            ProviderBrandReadScope = "api.parts/brand.read",
            ProviderBrandUrl = "https://example.com/brand"
        };

        _optionsMock.Setup(o => o.Value).Returns(_providerSettings);

        _brandService = new BrandService(
            _httpClientWrapperMock.Object,
            _authorisationServiceMock.Object,
            _optionsMock.Object,
            _loggerMock.Object
        );
    }

    [Test]
    public async Task GetBrandAsync_ReturnsSuccess_WhenTokenAndRequestAreValid() {
        // Arrange
        var expectedToken = "valid_token";
        var expectedUrl = $"{_providerSettings.ProviderBrandUrl}?page=1&pageSize=10";
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderBrandReadScope))
            .ReturnsAsync(expectedToken);

        _httpClientWrapperMock
            .Setup(h => h.GetAsync(expectedUrl, expectedToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _brandService.GetBrandAsync(1, 10);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        _authorisationServiceMock.Verify(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderBrandReadScope), Times.Once);
        _httpClientWrapperMock.Verify(h => h.GetAsync(expectedUrl, expectedToken), Times.Once);
    }

    [Test]
    public async Task GetBrandAsync_ReturnsBadRequest_WhenTokenIsNull() {
        // Arrange
        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderBrandReadScope))
            .ReturnsAsync((string)null!);

        // Act
        var response = await _brandService.GetBrandAsync(1, 10);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        _httpClientWrapperMock.Verify(h => h.GetAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task GetBrandAsync_ReturnsBadRequest_WhenExceptionIsThrown() {
        // Arrange
        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderBrandReadScope))
            .ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var response = await _brandService.GetBrandAsync(1, 10);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(await response.Content.ReadAsStringAsync() == "An unexpected error occurred.Please try again later or. Exception: Unexpected error", Is.True);
    }
}