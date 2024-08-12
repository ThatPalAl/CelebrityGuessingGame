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
        public async Task<Celebrity?> GetCelebrityByNameAsync(string apiKey, string name)
        {
            try
            {
                var encodedName = Uri.EscapeDataString(name);
                var requestUrl = $"https://api.api-ninjas.com/v1/celebrity?name={encodedName}&X-Api-Key={Uri.EscapeDataString(apiKey)}";

                Console.WriteLine("Constructed URL: " + requestUrl);
                

                var response = await _httpClient.GetAsync(requestUrl);
                Console.WriteLine("Sent request to API.");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response: " + content);
                    var celebrities = JsonConvert.DeserializeObject<List<Celebrity>>(content);
                    return celebrities?.FirstOrDefault();
                }
                else
                {
                    Console.WriteLine("API Error: " + response.StatusCode);
                    Console.WriteLine("API Response Status Code: " + response.StatusCode);
                    Console.WriteLine("API Response Headers: " + response.Headers);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                return null;
            }
        }


    }
}