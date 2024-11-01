using AutomotivePartsOrdering.Domain.Entities;
using AutomotivePartsOrdering.Data.Repositories;

namespace AutomotivePartsOrdering.Application.Services {
    public class OrderService {
        private readonly IOrderRepository _orderRepository;
        private readonly IPartRepository _partRepository;

        public OrderService(IOrderRepository orderRepository, IPartRepository partRepository) {
            _orderRepository = orderRepository;
            _partRepository = partRepository;
        }

        public async Task<Order> CreateOrderAsync(List<(string partCode, int quantity)> items) {
            var order = new Order();

            foreach (var (partCode, quantity) in items) {
                var part = await _partRepository.GetByCodeAsync(partCode);
                if (part == null)
                    throw new KeyNotFoundException($"Part with code {partCode} not found.");

                part.AdjustStock(-quantity);
                order.AddOrderLine(part, quantity);
            }

            await _orderRepository.AddAsync(order);
            return order;
        }
    }
}