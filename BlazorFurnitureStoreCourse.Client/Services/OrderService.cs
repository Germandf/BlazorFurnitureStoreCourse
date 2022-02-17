using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetNextNumber()
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/Order/GetNextNumber");
        }

        public async Task SaveOrder(Order order)
        {
            if (order.Id == 0)
                await _httpClient.PostAsJsonAsync($"api/Order", order);
            // TODO else
        }
    }
}
