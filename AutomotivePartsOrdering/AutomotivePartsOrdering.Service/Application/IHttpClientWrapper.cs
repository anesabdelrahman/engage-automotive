namespace AutomotivePartsOrdering.Service.Application {

    public interface IHttpClientWrapper {

        Task<HttpResponseMessage> GetAsync(string url, string scope);
        Task<HttpResponseMessage> PutAsync(Uri uri, StringContent request, string clientName, string scope);
        Task<HttpResponseMessage> PostAsync(HttpContent content, string requestUri, string scope);
    }
}
