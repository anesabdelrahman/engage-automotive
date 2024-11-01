namespace AutomotivePartsOrdering.Service.Domain {
    public class PartsOrder {
        public int Id { get; set; }
        public DateTime PartsOrderDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public string OrderReference { get; set; }

        public Customer Customer { get; set; }
        public Company Company { get; set; }
        public OrderContact OrderContact { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }

        public List<PartsOrderLine> Parts { get; set; }
    }
}

