using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
        Task<IEnumerable<Order>> GetAll();
    }
}
