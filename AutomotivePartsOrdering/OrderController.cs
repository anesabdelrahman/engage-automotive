using Microsoft.AspNetCore.Mvc;
using AutomotivePartsOrdering.Application.Services;

namespace AutomotivePartsOrdering.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService) {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] List<OrderItemDto> orderItems) {
            var items = orderItems.Select(i => (i.PartCode, i.Quantity)).ToList();
            var order = await _orderService.CreateOrderAsync(items);
            return Ok(order);
        }
    }

    public class OrderItemDto {
        public string PartCode { get; set; }
        public int Quantity { get; set; }
    }
}