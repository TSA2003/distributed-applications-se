using Client.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Client.Helpers
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly SessionStorage _sessionStorage;
        private readonly string _baseUrl;

        public ApiClient(HttpClient httpClient, SessionStorage sessionStorage, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
            _baseUrl = appSettings.Value.BaseUrl;
        }

        public async Task<ApiResponseResult<TResponseModel>> GetAsync<TResponseModel>(string url) where TResponseModel : class
        {
            var result = new ApiResponseResult<TResponseModel>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sessionStorage.Token);
            var response = await _httpClient.GetAsync(_baseUrl + url);
            result.StatusCode = response.StatusCode;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _sessionStorage.Token = "";
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<TResponseModel>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return result;
        }

        public async Task<ApiResponseResult<TResponseModel>> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel data) where TRequestModel : class where TResponseModel : class
        {
            var result = new ApiResponseResult<TResponseModel>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sessionStorage.Token);
            var body = JsonContent.Create(data);
            var response = await _httpClient.PostAsync(_baseUrl + url, body);
            result.StatusCode = response.StatusCode;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _sessionStorage.Token = "";               
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<TResponseModel>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return result;
        }

        public async Task<ApiResponseResult<TResponseModel>> PutAsync<TRequestModel, TResponseModel>(string url, TRequestModel data) where TRequestModel : class where TResponseModel : class
        {
            var result = new ApiResponseResult<TResponseModel>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sessionStorage.Token);
            var body = JsonContent.Create(data);
            var response = await _httpClient.PutAsync(_baseUrl + url, body);
            result.StatusCode = response.StatusCode;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _sessionStorage.Token = "";              
            }

            return result;
        }

        public async Task<ApiResponseResult<TResponseModel>> DeleteAsync<TResponseModel>(string url) where TResponseModel : class
        {
            var result = new ApiResponseResult<TResponseModel>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sessionStorage.Token);
            var response = await _httpClient.DeleteAsync(_baseUrl + url);
            result.StatusCode = response.StatusCode;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _sessionStorage.Token = "";               
            }

            return result;
        }
    }
}
