using System.Collections.Generic;
using System;

namespace AutomotivePartsOrdering.Domain {
    public class Order {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public decimal TotalAmount => OrderLines.Sum(line => line.TotalPrice);

        public void AddOrderLine(Part part, int quantity) {
            OrderLines.Add(new OrderLine { Part = part, Quantity = quantity, UnitPrice = part.Price });
        }
    }

    public class OrderLine {
        public Guid Id { get; set; }
        public Part Part { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}