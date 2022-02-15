using BlazorFurnitureStoreCourse.Repositories;
using BlazorFurnitureStoreCourse.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFurnitureStoreCourse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(nameof(GetByCategory) + "/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _productRepository.GetByCategory(productCategoryId);
        }
    }
}
