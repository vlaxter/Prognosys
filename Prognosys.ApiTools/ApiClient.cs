using Newtonsoft.Json;
using Prognosys.ApiTools.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Prognosys.ApiTools
{
    public class ApiClient : IApiClient
    {
        private HttpClient _httpClient;

        public ApiClient(string baseUri)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUri);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T Get<T>(string requestUri)
        {
            var response = _httpClient.GetAsync(requestUri).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }

            var responseModel = JsonConvert.DeserializeObject<T>(responseData);

            return responseModel;
        }

        public T Post<T>(string requestUri, object request)
        {
            var response = _httpClient.PostAsJsonAsync(requestUri, request).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }

            var responseModel = JsonConvert.DeserializeObject<T>(responseData);

            return responseModel;
        }

        public void Post(string requestUri, object request)
        {
            var response = _httpClient.PostAsJsonAsync(requestUri, request).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }
        }

        public T Put<T>(string requestUri, object request)
        {
            var response = _httpClient.PutAsJsonAsync(requestUri, request).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }

            var responseModel = JsonConvert.DeserializeObject<T>(responseData);

            return responseModel;
        }
        
        public void Put(string requestUri, object request)
        {
            var response = _httpClient.PutAsJsonAsync(requestUri, request).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }
        }

        public void Delete(string requestUri)
        {
            var response = _httpClient.DeleteAsync(requestUri).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException((int)response.StatusCode, responseData);
            }
        }
        
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
