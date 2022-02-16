using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
    }
}
