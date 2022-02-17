using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IOrderProductRepository
    {
        Task<bool> InsertOrderProduct(int orderId, Product product);
    }
}
