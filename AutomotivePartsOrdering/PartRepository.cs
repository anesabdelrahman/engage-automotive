using Microsoft.EntityFrameworkCore;
using AutomotivePartsOrdering.Domain.Entities;

namespace AutomotivePartsOrdering.Data.Repositories {
    public class PartRepository : IPartRepository {
        private readonly AppDbContext _context;

        public PartRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Part> GetByCodeAsync(string code) {
            return await _context.Parts.SingleOrDefaultAsync(p => p.Code == code);
        }

        public async Task AddAsync(Part part) {
            await _context.Parts.AddAsync(part);
            await _context.SaveChangesAsync();
        }
    }
}