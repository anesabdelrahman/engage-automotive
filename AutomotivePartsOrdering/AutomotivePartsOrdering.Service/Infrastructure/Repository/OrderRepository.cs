﻿using AutomotivePartsOrdering.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutomotivePartsOrdering.Service.Infrastructure.Repository {
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<PartsOrder> GetByIdAsync(int orderId) {
            // Include OrderLines and Parts for full order details
            return await context.Orders
                .Include(o => o.Parts)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task AddAsync(PartsOrder order) {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
    }
}
