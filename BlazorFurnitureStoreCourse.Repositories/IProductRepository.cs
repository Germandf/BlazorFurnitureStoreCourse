using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetDetails(int productId);
    }
}
