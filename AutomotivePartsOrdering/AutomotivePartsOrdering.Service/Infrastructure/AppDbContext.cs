using AutomotivePartsOrdering.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutomotivePartsOrdering.Service.Infrastructure {
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderContact> OrderContacts { get; set; }
        public DbSet<Address> DeliveryAddresses { get; set; }
        public DbSet<Address> AlternateDeliveryAddresses { get; set; }
        public DbSet<OrderLine> PartsOrderLines { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<VehicleReference> VehicleReferences { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>().HasKey(p => p.Id);

            // Configure relationships and constraints for Order entity

            modelBuilder.Entity<Order>()
                .HasOne(p => p.OrderContact);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.DeliveryAddress);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.AlternateDeliveryAddress);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.MandatoryVehicleReference);

            modelBuilder.Entity<Order>()
                .HasMany(p => p.Parts)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Property(p => p.OrderStatus)
                .HasConversion<int>();

            modelBuilder.Entity<Order>()
                .Property(p => p.OrderType)
                .HasConversion<int>()
                .IsRequired();

        }
    }
}