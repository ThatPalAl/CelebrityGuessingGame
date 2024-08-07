using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiService
{
    private readonly HttpClient _client;

    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Celebrity>> GetCelebritiesAsync(string apiKey)
    {
        _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        var response = await _client.GetStringAsync("https://api.api-ninjas.com/v1/celebrity");
        return JsonConvert.DeserializeObject<List<Celebrity>>(response);
    }
}