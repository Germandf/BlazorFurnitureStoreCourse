using BlazorFurnitureStoreCourse.Repositories;
using BlazorFurnitureStoreCourse.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BlazorFurnitureStoreCourse.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderController(
            IOrderRepository orderRepository, 
            IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.GetAll();
        }

        [HttpGet(nameof(GetNextNumber))]
        public async Task<int> GetNextNumber()
        {
            return await _orderRepository.GetNextNumber();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            order.Id = await _orderRepository.GetNextId();
            if (order is null)
                return BadRequest();

            if (order.OrderNumber == 0)
                ModelState.AddModelError(nameof(order.OrderNumber), $"{nameof(order.OrderNumber)} can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = false;
            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                success = await _orderRepository.InsertOrder(order);
                if(order.Products is not null && order.Products.Any())
                    foreach (var product in order.Products)
                        success = await _orderProductRepository.InsertOrderProduct(order.Id, product);
                scope.Complete();
            }

            if (success)
                return NoContent();
            return Conflict();
        }
    }
}
