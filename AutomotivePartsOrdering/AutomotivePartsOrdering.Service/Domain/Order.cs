using AutomotivePartsOrdering.Service.Domain.Enums;

namespace AutomotivePartsOrdering.Service.Domain
{
    public class Order {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? PartsOrderDateTime { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public string OrderReference { get; set; } = null!;
        public VehicleReference? MandatoryVehicleReference { get; set; }
        public virtual OrderContact OrderContact { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        public virtual Address? AlternateDeliveryAddress { get; set; }

        public virtual ICollection<OrderLine>? Parts { get; set; }
    }
}

