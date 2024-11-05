using System.Net;
using System.Text;
using System.Text.Json;
using AutomotivePartsOrdering.Service.Application.Mapping;
using AutomotivePartsOrdering.Service.Domain;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;
using AutomotivePartsOrdering.Service.Middleware;
using Microsoft.Extensions.Options;

namespace AutomotivePartsOrdering.Service.Application
{
    public class OrderService(IOrderRepository orderRepository, IHttpClientWrapper httpClientWrapper, IAuthorisationService authorisationService, IOptions<ProviderSettings> options, ILogger<OrderService> logger) : IOrderService
    {
        public async Task<HttpResponseMessage> CreateOrderAsync(Order order) {
            try {
                await orderRepository.AddAsync(order);
                var orderDto = OrderMapper.MapOrderToDto(order);
                var jsonContent = JsonSerializer.Serialize(orderDto);
                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderOrderCreateScope);
                var url = CreatePostUrl();

                if (token != null)
                {
                    return await httpClientWrapper.PostAsync(content, url, token);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                logger.LogError($"{nameof(CreateOrderAsync)}: {exception.Message}");
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application/json")
                };
            }
        }

        public async Task<HttpResponseMessage> GetOrderAsync(string partsOrderId)
        {
            try {
                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderOrderReadScope);
                var url = CreateGetUrl(partsOrderId);
                if (token != null)
                {
                    return await httpClientWrapper.GetAsync(url, token);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception exception) {
                logger.LogError($"{nameof(GetOrderAsync)}: {exception.Message}");
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application/json")
                };
            }
        }

        private string CreatePostUrl() {
            var url = options.Value.ProviderOrderUrl;
            return url;
        }

        private string CreateGetUrl(string partsOrderId) {
            var url = $"{options.Value.ProviderOrderUrl}/{partsOrderId}";
            return url;
        }
    }
}