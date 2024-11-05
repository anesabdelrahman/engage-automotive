namespace AutomotivePartsOrdering.Service.Application {

    public interface IHttpClientWrapper {

        Task<HttpResponseMessage> GetAsync(string url, string token);
        Task<HttpResponseMessage> PutAsync(HttpContent content, string requestUri, string token);
        Task<HttpResponseMessage> PostAsync(HttpContent content, string requestUri, string token);
        Task<HttpResponseMessage> PostAsync(string tokenUrl, FormUrlEncodedContent requestContent);
    }
}
