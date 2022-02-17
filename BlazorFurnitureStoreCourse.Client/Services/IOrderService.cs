using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
        Task<int> GetNextNumber();
        Task<IEnumerable<Order>> GetAll();
    }
}
