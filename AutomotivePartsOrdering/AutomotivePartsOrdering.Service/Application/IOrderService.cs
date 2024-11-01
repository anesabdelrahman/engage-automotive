using AutomotivePartsOrdering.Service.Domain;

namespace AutomotivePartsOrdering.Service.Application;

public interface IOrderService
{
    Task<PartsOrder> CreateOrderAsync(List<(string partCode, int quantity)> items);
    Task<PartsOrder> GetOrderAsync(string partsOrderId);
}