using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text;

namespace AutomotivePartsOrdering.Service.Application {
    public class BrandService(IHttpClientWrapper httpClientWrapper, IConfiguration configuration, IOptions<ProviderSettings> options, ILogger<BrandService> logger) : IBrandService
    {
        public async Task<HttpResponseMessage> GetBrandAsync(int page, int pageSize)
        {
            try {
                var (url, scope) = CreateGetUrl( page, pageSize);
                return await httpClientWrapper.GetAsync(url, scope);
            }
            catch (Exception exception) {

                logger.LogError($"{nameof(GetBrandAsync)}: {exception.Message}");

                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application / json")
                };
            }
        }

        private (string url, string scope) CreateGetUrl(int page, int pageSize) {
            var url = $"{options.Value.ProviderBrandUrl}?page={page}&pageSize={pageSize}";
            var scope = options.Value.ProviderBrandReadScope;
            return (url, scope);
        }
    }
}