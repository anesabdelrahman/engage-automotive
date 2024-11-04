namespace AutomotivePartsOrdering.Service.Application;

public interface IBrandService {
    Task<HttpResponseMessage> GetBrandAsync(int page, int pageSize);
}