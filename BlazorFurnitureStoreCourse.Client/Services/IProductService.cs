using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByCategory(int productCategoryId);
        Task<Product> GetDetails(int productId);
    }
}
