namespace AutomotivePartsOrdering.Service.Domain;

public enum OrderStatus {
    OPEN,
    RESERVED,
    ISSUED,
    BACKORDER,
    PACKED,
    INTRANSIT,
    DELIVERED,
    CANCELLED,
    INVOICED
}