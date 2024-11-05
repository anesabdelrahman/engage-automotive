using AutomotivePartsOrdering.Service.Dto;

namespace AutomotivePartsOrdering.Service.Application;

public interface IBrandService {
    Task<BrandsDto?> GetBrandAsync(int page, int pageSize);
}