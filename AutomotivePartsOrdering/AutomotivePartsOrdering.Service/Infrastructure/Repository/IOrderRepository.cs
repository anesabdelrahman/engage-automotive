using AutomotivePartsOrdering.Service.Domain;

namespace AutomotivePartsOrdering.Service.Infrastructure.Repository;

public interface IOrderRepository {
    Task<PartsOrder> GetByIdAsync(int orderId);
    Task AddAsync(PartsOrder order);
}