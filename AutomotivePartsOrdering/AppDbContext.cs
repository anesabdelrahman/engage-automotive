using Microsoft.EntityFrameworkCore;
using AutomotivePartsOrdering.Domain;

namespace AutomotivePartsOrdering.Data.Repositories {
    public class AppDbContext : DbContext {
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Part>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderLine>().HasKey(ol => ol.Id);
        }
    }
}