using BlazorFurnitureStoreCourse.Shared;
using Dapper;
using System.Data;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            var sql = @"SELECT Id, Name, Price, CategoryId as ProductCategoryId
                        FROM Products
                        WHERE CategoryId = @Id";
            return await _dbConnection.QueryAsync<Product>(sql, new { Id = productCategoryId });
        }

        public async Task<Product> GetDetails(int productId)
        {
            var sql = @"SELECT Id, Name, Price, CategoryId as ProductCategoryId
                        FROM Products
                        WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = productId });
        }
    }
}
