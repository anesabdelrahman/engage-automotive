namespace AutomotivePartsOrdering.Domain {
    public class Part {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public void AdjustStock(int quantity) {
            if (quantity < 0 && Stock < -quantity)
                throw new InvalidOperationException("Insufficient stock.");

            Stock += quantity;
        }
    }
}