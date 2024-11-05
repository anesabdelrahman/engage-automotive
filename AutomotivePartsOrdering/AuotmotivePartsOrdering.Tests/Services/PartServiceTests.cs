using System.Net;
using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace AutomotivePartsOrdering.Tests.Services;

[TestFixture(Category = "Services")]
public class PartServiceTests {
    private Mock<IHttpClientWrapper> _httpClientWrapperMock;
    private Mock<IAuthorisationService> _authorisationServiceMock;
    private Mock<IOptions<ProviderSettings>> _optionsMock;
    private Mock<ILogger<PartService>> _loggerMock;
    private ProviderSettings _providerSettings;

    private PartService _partService;

    [SetUp]
    public void Setup() {
        _httpClientWrapperMock = new Mock<IHttpClientWrapper>();
        _authorisationServiceMock = new Mock<IAuthorisationService>();
        _optionsMock = new Mock<IOptions<ProviderSettings>>();
        _loggerMock = new Mock<ILogger<PartService>>();

        _providerSettings = new ProviderSettings {
            ProviderPartsUrl = "https://example.com/parts",
            ProviderPartReadScope = "api.parts/read"
        };
        _optionsMock.Setup(o => o.Value).Returns(_providerSettings);

        _partService = new PartService(
            _httpClientWrapperMock.Object,
            _optionsMock.Object,
            _authorisationServiceMock.Object,
            _loggerMock.Object
        );
    }

    [Test]
    public async Task GetPartAsync_ReturnsSuccess_WhenTokenIsValid() {
        // Arrange
        var expectedToken = "valid_token";
        var brandCode = "brand123";
        var partCode = "part456";
        var page = 1;
        var pageSize = 10;
        var expectedUrl = $"{_providerSettings.ProviderPartsUrl}?brandCode={brandCode}&partCode={partCode}&page={page}&pageSize={pageSize}";
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderPartReadScope))
            .ReturnsAsync(expectedToken);

        _httpClientWrapperMock
            .Setup(h => h.GetAsync(expectedUrl, expectedToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _partService.GetPartAsync(brandCode, partCode, page, pageSize);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        _authorisationServiceMock.Verify(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderPartReadScope), Times.Once);
        _httpClientWrapperMock.Verify(h => h.GetAsync(expectedUrl, expectedToken), Times.Once);
    }

    [Test]
    public async Task GetPartAsync_ReturnsBadRequest_WhenTokenIsNull() {
        // Arrange
        var brandCode = "brand123";
        var partCode = "part456";
        var page = 1;
        var pageSize = 10;

        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderPartReadScope))
            .ReturnsAsync((string)null);

        // Act
        var response = await _partService.GetPartAsync(brandCode, partCode, page, pageSize);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        _httpClientWrapperMock.Verify(h => h.GetAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task GetPartAsync_ReturnsBadRequest_WhenExceptionIsThrown() {
        // Arrange
        var brandCode = "brand123";
        var partCode = "part456";
        var page = 1;
        var pageSize = 10;

        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderPartReadScope))
            .ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var response = await _partService.GetPartAsync(brandCode, partCode, page, pageSize);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(await response.Content.ReadAsStringAsync() == "An unexpected error occurred.Please try again later or. Exception: Unexpected error");
    }
}