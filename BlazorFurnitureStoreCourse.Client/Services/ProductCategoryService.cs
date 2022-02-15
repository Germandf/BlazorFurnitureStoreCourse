using BlazorFurnitureStoreCourse.Shared;
using System.Net.Http.Json;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductCategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var client = _httpClientFactory.CreateClient("BlazorApp.PublicServerAPI");
            return await client.GetFromJsonAsync<IEnumerable<ProductCategory>>("api/ProductCategory") 
                ?? new List<ProductCategory>();
        }
    }
}
