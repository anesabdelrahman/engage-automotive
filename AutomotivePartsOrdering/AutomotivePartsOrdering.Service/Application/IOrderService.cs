using AutomotivePartsOrdering.Service.Domain;

namespace AutomotivePartsOrdering.Service.Application;

public interface IOrderService
{
    Task<HttpResponseMessage> CreateOrderAsync(Order order);
    Task<HttpResponseMessage> GetOrderAsync(string partsOrderId);
}