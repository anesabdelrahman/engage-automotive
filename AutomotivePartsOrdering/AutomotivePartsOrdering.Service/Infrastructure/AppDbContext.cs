using AutomotivePartsOrdering.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutomotivePartsOrdering.Service.Infrastructure {
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<PartsOrder> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<PartsOrder>().HasKey(p => p.Id);
        }
    }
}