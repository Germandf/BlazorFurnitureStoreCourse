using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SaveOrder(Order order)
        {
            var client = _httpClientFactory.CreateClient("BlazorApp.PublicServerAPI");
            if (order.Id == 0)
                await client.PostAsJsonAsync($"api/Order", order);
            // TODO else
        }
    }
}
