using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
    }

    public class HttpService : IHttpService
    {
        public HttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson =JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseWrapper<TResponse>(await DeserializeJson<TResponse>(response), response.IsSuccessStatusCode, response);
            }
            else {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
        }

        private async Task<T> DeserializeJson<T>(HttpResponseMessage httpResponseMessage) {
            return JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
