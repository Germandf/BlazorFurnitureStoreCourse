using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
    }
}
