using BlazorFurnitureStoreCourse.Shared;
using Dapper;
using System.Data;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertOrderProduct(int orderId, Product product)
        {
            var sql = @"INSERT INTO OrderProducts (OrderId, ProductId, Quantity)
                        VALUES (@OrderId, @ProductId, @Quantity)";
            var result = await _dbConnection.ExecuteAsync(sql, new { OrderId = orderId, ProductId = product.Id, Quantity = product.Quantity });
            return result > 0;
        }
    }
}
