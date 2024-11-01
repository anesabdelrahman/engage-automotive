using AutomotivePartsOrdering.Service.Domain;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;

namespace AutomotivePartsOrdering.Service.Application {
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<PartsOrder> CreateOrderAsync(List<(string partCode, int quantity)> items) {
            var order = new PartsOrder();

            foreach (var (partCode, quantity) in items)
            {
                //TODO: 
                //if (part == null)
                //    throw new KeyNotFoundException($"Part with code {partCode} not found.");

            }

            await orderRepository.AddAsync(order);
            return order;
        }

        public Task<PartsOrder> GetOrderAsync(string partsOrderId)
        {
            return Task.FromResult(new PartsOrder());
        }
    }
}