namespace AutomotivePartsOrdering.Service.Domain;

public enum PartsOrderLineStatus {
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