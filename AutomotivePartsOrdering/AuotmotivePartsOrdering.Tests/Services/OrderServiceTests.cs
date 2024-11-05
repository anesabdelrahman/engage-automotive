using System.Net;
using System.Text.Json;
using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Application.Mapping;
using AutomotivePartsOrdering.Service.Domain;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;
using AutomotivePartsOrdering.Service.Middleware;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace AutomotivePartsOrdering.Tests.Services;

[TestFixture(Category = "Services")]
public class OrderServiceTests {
    private Mock<IOrderRepository> _orderRepositoryMock;
    private Mock<IHttpClientWrapper> _httpClientWrapperMock;
    private Mock<IAuthorisationService> _authorisationServiceMock;
    private Mock<IOptions<ProviderSettings>> _optionsMock;
    private Mock<ILogger<OrderService>> _loggerMock;
    private ProviderSettings _providerSettings;

    private OrderService _orderService;

    [SetUp]
    public void Setup() {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _httpClientWrapperMock = new Mock<IHttpClientWrapper>();
        _authorisationServiceMock = new Mock<IAuthorisationService>();
        _optionsMock = new Mock<IOptions<ProviderSettings>>();
        _loggerMock = new Mock<ILogger<OrderService>>();

        _providerSettings = new ProviderSettings {
            ProviderOrderUrl = "https://example.com/order",
            ProviderOrderCreateScope = "api.orders/create",
            ProviderOrderReadScope = "api.orders/read"
        };
        _optionsMock.Setup(o => o.Value).Returns(_providerSettings);

        _orderService = new OrderService(
            _orderRepositoryMock.Object,
            _httpClientWrapperMock.Object,
            _authorisationServiceMock.Object,
            _optionsMock.Object,
            _loggerMock.Object
        );
    }

    [Test]
    public async Task CreateOrderAsync_ReturnsBadRequest_WhenTokenIsNull() {
        // Arrange
        var order = new Order();
        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderOrderCreateScope))
            .ReturnsAsync((string)null);

        // Act
        var response = await _orderService.CreateOrderAsync(order);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        _httpClientWrapperMock.Verify(h => h.PostAsync(It.IsAny<StringContent>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task CreateOrderAsync_ReturnsBadRequest_WhenExceptionIsThrown() {
        // Arrange
        var order = new Order();
        _orderRepositoryMock.Setup(repo => repo.AddAsync(order)).ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var response = await _orderService.CreateOrderAsync(order);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.IsTrue(await response.Content.ReadAsStringAsync() == "An unexpected error occurred.Please try again later or. Exception: Unexpected error");
    }

    [Test]
    public async Task GetOrderAsync_ReturnsSuccess_WhenTokenAndRequestAreValid() {
        // Arrange
        var expectedToken = "valid_token";
        var partsOrderId = "12345";
        var expectedUrl = $"{_providerSettings.ProviderOrderUrl}/{partsOrderId}";
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderOrderReadScope))
            .ReturnsAsync(expectedToken);

        _httpClientWrapperMock
            .Setup(h => h.GetAsync(expectedUrl, expectedToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var response = await _orderService.GetOrderAsync(partsOrderId);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        _authorisationServiceMock.Verify(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderOrderReadScope), Times.Once);
        _httpClientWrapperMock.Verify(h => h.GetAsync(expectedUrl, expectedToken), Times.Once);
    }

    [Test]
    public async Task GetOrderAsync_ReturnsBadRequest_WhenTokenIsNull() {
        // Arrange
        var partsOrderId = "12345";
        _authorisationServiceMock
            .Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderOrderReadScope))
            .ReturnsAsync((string)null!);

        // Act
        var response = await _orderService.GetOrderAsync(partsOrderId);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        _httpClientWrapperMock.Verify(h => h.GetAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task GetOrderAsync_ReturnsBadRequest_WhenExceptionIsThrown() {
        // Arrange
        var partsOrderId = "12345";
        _authorisationServiceMock.Setup(a => a.GetAccessTokenAsync(_optionsMock.Object, _providerSettings.ProviderOrderReadScope))
            .ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var response = await _orderService.GetOrderAsync(partsOrderId);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.IsTrue(await response.Content.ReadAsStringAsync() == "An unexpected error occurred.Please try again later or. Exception: Unexpected error");
    }
}