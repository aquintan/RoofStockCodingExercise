using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RoofStock.CodingExercise.UI.Contracts;
using RoofStock.CodingExercise.UI.Models;

namespace RoofStock.CodingExercise.UI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PropertyModel>> GetProperties()
        {
            var responseString = await _httpClient.GetStringAsync($"/api/property");

            var res = JsonConvert.DeserializeObject<List<PropertyModel>>(responseString);

            return res;
        }

        public async Task<PropertyModel> GetProperty(Guid id)
        {
            var responseString = await _httpClient.GetStringAsync($"/api/property/{id}");

            var res = JsonConvert.DeserializeObject<PropertyModel>(responseString);

            return res;
        }

        public async Task UpdateProperty(PropertyModel property)
        {
            var json = JsonConvert.SerializeObject(property);

            var submitOrderHttpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "/api/property/")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(submitOrderHttpRequestMessage);
        }

        public async Task CreateProperty(PropertyModel property)
        {
            var json = JsonConvert.SerializeObject(property);

            var submitOrderHttpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/property/")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(submitOrderHttpRequestMessage);
        }

        public async Task DeleteProperty(Guid id)
        {
            var responseString = await _httpClient.DeleteAsync($"/api/property/{id}");
        }
    }
}
