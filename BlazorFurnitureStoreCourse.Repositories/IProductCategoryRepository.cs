using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAll();
    }
}
