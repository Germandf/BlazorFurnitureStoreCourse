using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}
