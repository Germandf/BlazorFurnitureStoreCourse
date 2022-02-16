using BlazorFurnitureStoreCourse.Repositories;
using BlazorFurnitureStoreCourse.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFurnitureStoreCourse.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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

            var success = await _orderRepository.InsertOrder(order);
            if (success)
                return NoContent();
            return Conflict();
        }
    }
}
