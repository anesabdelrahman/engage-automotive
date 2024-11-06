namespace AutomotivePartsOrdering.Service.Domain;

public class OrderContact {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; }
    public string CompanyName { get; set; } = null!;
}