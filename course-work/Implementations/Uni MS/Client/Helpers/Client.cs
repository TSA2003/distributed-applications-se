using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Client.Helpers
{
    public class Client
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public Client(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _baseUrl = appSettings.Value.BaseUrl;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string token)
        {
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", "");
            return await _httpClient.GetAsync(_baseUrl + url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string token, object data)
        {
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", "");
            var body = JsonContent.Create(data);
            return await _httpClient.PostAsync(_baseUrl + url, body);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, string token, object data)
        {
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", "");
            var body = JsonContent.Create(data);
            return await _httpClient.PutAsync(_baseUrl + url, body);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, string token)
        {
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", "");
            return await _httpClient.DeleteAsync(_baseUrl + url);
        }
    }
}
