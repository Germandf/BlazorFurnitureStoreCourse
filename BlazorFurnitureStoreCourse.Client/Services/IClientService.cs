namespace BlazorFurnitureStoreCourse.Client.Services
{
    public interface IClientService
    {
        Task<IEnumerable<BlazorFurnitureStoreCourse.Shared.Client>> GetClients();
    }
}
