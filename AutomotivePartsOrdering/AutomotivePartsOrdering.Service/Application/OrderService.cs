using System.Net;
using System.Text;
using System.Text.Json;
using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using AutomotivePartsOrdering.Service.Domain;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;
using Microsoft.Extensions.Options;

namespace AutomotivePartsOrdering.Service.Application {
    public class OrderService(IOrderRepository orderRepository, IHttpClientWrapper httpClientWrapper, IConfiguration configuration, IOptions<ProviderSettings> options, ILogger<OrderService> logger) : IOrderService
    {
        const string OrderProvider = "ProviderOrderUrl";

        public async Task<HttpResponseMessage> CreateOrderAsync(Order order) {
            try {
                await orderRepository.AddAsync(order);
                var orderDto = OrderMapper.MapOrderToDto(order);
                var jsonContent = JsonSerializer.Serialize(orderDto);
                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var (url, scope) = CreatePostUrl();
               
                return await httpClientWrapper.PostAsync(content, url, scope );
            }
            catch (Exception exception)
            {
                logger.LogError($"{nameof(CreateOrderAsync)}: {exception.Message}");
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application / json")
                };
            }
        }

        public async Task<HttpResponseMessage> GetOrderAsync(string partsOrderId)
        {
            try {
                var(url, scope) = CreateGetUrl(partsOrderId);
                return await httpClientWrapper.GetAsync(url, scope);
            }
            catch (Exception exception) {
                logger.LogError($"{nameof(GetOrderAsync)}: {exception.Message}");
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application / json")
                };
            }
        }

        private (string url, string scope) CreatePostUrl() {
            var url = options.Value.ProviderOrderUrl;
            var scope = options.Value.ProviderOrderCreateScope;
            return (url, scope);
        }

        private (string url, string scope) CreateGetUrl(string partsOrderId) {
            var url = $"{options.Value.ProviderOrderUrl}/{partsOrderId}";
            var scope = options.Value.ProviderOrderReadScope;
            return (url, scope);
        }
    }
}