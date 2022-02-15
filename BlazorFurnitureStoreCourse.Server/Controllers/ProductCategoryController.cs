using BlazorFurnitureStoreCourse.Repositories;
using BlazorFurnitureStoreCourse.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFurnitureStoreCourse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            return await _productCategoryRepository.GetAll();
        }
    }
}
