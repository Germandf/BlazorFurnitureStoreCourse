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
            var orders = await _orderRepository.GetAll();
            foreach (var item in orders)
                item.Products = (await _orderProductRepository.GetByOrder(item.Id)).ToList();
            return orders;
        }

        [HttpGet("{id}")]
        public async Task<Order> GetDetails(int id)
        {
            var order = await _orderRepository.GetDetails(id);
            if(order is not null)
            {
                var products = await _orderProductRepository.GetByOrder(id);
                order.Products = products.ToList();
            }
            return order;
        }

        [HttpGet(nameof(GetNextNumber))]
        public async Task<int> GetNextNumber()
        {
            return await _orderRepository.GetNextNumber();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order is null)
                return BadRequest();

            if (order.OrderNumber == 0)
                ModelState.AddModelError(nameof(order.OrderNumber), $"{nameof(order.OrderNumber)} can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = false;
            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                order.Id = await _orderRepository.GetNextId();
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            if (order is null)
                return BadRequest();

            if (order.OrderNumber == 0)
                ModelState.AddModelError(nameof(order.OrderNumber), $"{nameof(order.OrderNumber)} can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = false;
            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                success = await _orderRepository.UpdateOrder(order);
                success = await _orderProductRepository.DeleteByOrder(order.Id);
                if (order.Products is not null && order.Products.Any())
                    foreach (var product in order.Products)
                        success = await _orderProductRepository.InsertOrderProduct(order.Id, product);
                scope.Complete();
            }

            if (success)
                return NoContent();
            return Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
    }
}
