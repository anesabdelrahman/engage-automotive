using AutomotivePartsOrdering.Service.Middleware;
using Microsoft.Extensions.Options;
using AutomotivePartsOrdering.Service.Dto;

namespace AutomotivePartsOrdering.Service.Application
{
    public class BrandService(IHttpClientWrapper httpClientWrapper, IAuthorisationService authorisationService, IOptions<ProviderSettings> options, ILogger<BrandService> logger) : IBrandService
    {
        public async Task<BrandsDto?> GetBrandAsync(int page, int pageSize)
        {
            try {
                if (options.Value.UseStubbedData) {
                    return await StubbedDataLoaderService.LoadStubbedBrandDataAsync();
                }

                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderBrandReadScope);
                var url = CreateGetUrl( page, pageSize);

                if (token == null) 
                    return new BrandsDto();

                var response = await httpClientWrapper.GetAsync(url, token);
                return await response.Content.ReadFromJsonAsync<BrandsDto>();
            }
            catch (Exception exception) {

                logger.LogError($"{nameof(GetBrandAsync)}: {exception.Message}");

                return new BrandsDto();
            }
        }

        private string CreateGetUrl(int page, int pageSize) {
            var url = $"{options.Value.ProviderBrandUrl}?page={page}&pageSize={pageSize}";
            return url;
        }
    }
}