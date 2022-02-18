using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
        Task<Order> GetDetails(int id);
        Task<IEnumerable<Order>> GetAll();
    }
}
