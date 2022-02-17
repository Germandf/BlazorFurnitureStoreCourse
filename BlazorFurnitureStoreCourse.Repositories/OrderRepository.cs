using BlazorFurnitureStoreCourse.Shared;
using Dapper;
using System.Data;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetNextId()
        {
            var sql = @"SELECT IDENT_CURRENT('Orders') + 1";
            return await _dbConnection.QueryFirstAsync<int>(sql);
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @"SELECT MAX(OrderNumber) + 1
                        FROM Orders";
            return await _dbConnection.QueryFirstAsync<int>(sql);
        }

        public async Task<bool> InsertOrder(Order order)
        {
            var sql = @"INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
                        VALUES (@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)";
            var result =  await _dbConnection.ExecuteAsync(sql, new { order.OrderNumber, order.ClientId, order.OrderDate, order.DeliveryDate, order.Total });
            return result > 0;
        }
    }
}
