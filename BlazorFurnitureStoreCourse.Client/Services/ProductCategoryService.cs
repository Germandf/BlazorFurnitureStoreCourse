using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpClient;

        public ProductCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<ProductCategory>>("api/ProductCategory");
            return categories ?? new List<ProductCategory>();
        }
    }
}
