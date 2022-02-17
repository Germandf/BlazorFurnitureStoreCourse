using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product> GetDetails(int productId)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{productId}");
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int productCategoryId)
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/Product/GetByCategory/{productCategoryId}");
            return products ?? new List<Product>();
        }
    }
}
