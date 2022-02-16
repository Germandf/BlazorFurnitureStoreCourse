using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Client.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
    }
}
