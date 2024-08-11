using CelebrityGuessingGame.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CelebrityGuessingGame.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Celebrity>?> GetCelebritiesAsync(string apiKey)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            var response = await _httpClient.GetAsync("https://api.api-ninjas.com/v1/celebrity");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Celebrity>>(content);
            }
            else
            {
                // Log the error or return an empty list if there's a problem with the API call
                return new List<Celebrity>();
            }
        }
    }
}