using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text;

namespace AutomotivePartsOrdering.Service.Application {
    public class BrandService(IHttpClientWrapper httpClientWrapper, IAuthorisationService authorisationService, IOptions<ProviderSettings> options, ILogger<BrandService> logger) : IBrandService
    {
        public async Task<HttpResponseMessage> GetBrandAsync(int page, int pageSize)
        {
            try {
                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderBrandReadScope);
                var url = CreateGetUrl( page, pageSize);

                if (token != null)
                {
                    return await httpClientWrapper.GetAsync(url, token);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception exception) {

                logger.LogError($"{nameof(GetBrandAsync)}: {exception.Message}");

                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application/json")
                };
            }
        }

        private string CreateGetUrl(int page, int pageSize) {
            var url = $"{options.Value.ProviderBrandUrl}?page={page}&pageSize={pageSize}";
            return url;
        }
    }
}