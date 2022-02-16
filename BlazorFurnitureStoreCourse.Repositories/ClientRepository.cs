using BlazorFurnitureStoreCourse.Shared;
using Dapper;
using System.Data;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthDate, Phone, Address FROM Clients";
            return await _dbConnection.QueryAsync<Client>(sql);
        }
    }
}
