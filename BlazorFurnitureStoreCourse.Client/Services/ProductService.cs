using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int productCategoryId)
        {
            var client = _httpClientFactory.CreateClient("BlazorApp.PublicServerAPI");
            return await client.GetFromJsonAsync<IEnumerable<Product>>($"api/Product/GetByCategory/{productCategoryId}")
                    ?? new List<Product>();
        }
    }
}
