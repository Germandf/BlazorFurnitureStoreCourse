using BlazorFurnitureStoreCourse.Shared;
using Dapper;
using System.Data;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = @"SELECT Id, Name FROM ProductCategories";
            return await _dbConnection.QueryAsync<ProductCategory>(sql);
        }
    }
}
