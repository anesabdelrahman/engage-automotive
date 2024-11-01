using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutomotivePartsOrdering.Service.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrder(string partsOrderId) {
            try {
                var order = await orderService.GetOrderAsync(partsOrderId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] List<OrderItemDto> orderItems) {
            try {
                var items = orderItems.Select(i => (i.PartCode, i.Quantity)).ToList();
                var order = await orderService.CreateOrderAsync(items);
                return Ok(order);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}