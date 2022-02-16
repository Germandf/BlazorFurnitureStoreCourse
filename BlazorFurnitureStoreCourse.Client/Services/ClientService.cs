using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<BlazorFurnitureStoreCourse.Shared.Client>> GetClients()
        {
            var client = _httpClientFactory.CreateClient("BlazorApp.PublicServerAPI");
            return await client.GetFromJsonAsync<IEnumerable<BlazorFurnitureStoreCourse.Shared.Client>>("api/Client")
                ?? new List<BlazorFurnitureStoreCourse.Shared.Client>();
        }
    }
}
