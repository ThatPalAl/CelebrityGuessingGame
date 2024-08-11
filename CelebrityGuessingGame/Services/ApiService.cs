using CelebrityGuessingGame.Models;
using Newtonsoft.Json;

namespace CelebrityGuessingGame.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Celebrity>> GetCelebritiesAsync(string apiKey)
    {
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        var response = await _httpClient.GetAsync("https://api.api-ninjas.com/v1/celebrity");
        
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Celebrity>>(content);
        }

        return new List<Celebrity>();
    }
}