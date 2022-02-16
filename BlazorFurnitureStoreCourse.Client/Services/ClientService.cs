using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BlazorFurnitureStoreCourse.Shared.Client>> GetClients()
        {
            var clients = await _httpClient.GetFromJsonAsync<IEnumerable<BlazorFurnitureStoreCourse.Shared.Client>>("api/Client");
            return clients ?? new List<BlazorFurnitureStoreCourse.Shared.Client>();
        }
    }
}
