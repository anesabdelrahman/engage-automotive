using AutomotivePartsOrdering.Service.Domain;

namespace AutomotivePartsOrdering.Service.Infrastructure.Repository;

public interface IOrderRepository {
    Task<Order> GetByIdAsync(int orderId);
    Task AddAsync(Order order);
}