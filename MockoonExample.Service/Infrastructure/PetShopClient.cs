using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MockoonExample.Service.Infrastructure
{
    public class PetShopClient : IPetShopClient
    {
        private readonly HttpClient _httpClient;

        public PetShopClient(HttpClient httpClient, IOptions<PetShopClientOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }


        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"pet/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pet>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Pet?> CreatePetAsync(Pet pet)
        {
            var response = await _httpClient.PostAsJsonAsync("pet", pet);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pet>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
