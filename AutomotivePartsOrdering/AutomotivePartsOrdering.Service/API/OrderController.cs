using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutomotivePartsOrdering.Service.API {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetOrder(string partsOrderId) {
            var response = await orderService.GetOrderAsync(partsOrderId);

            if (response.IsSuccessStatusCode) {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order) {
            var response = await orderService.CreateOrderAsync(order);
            if (response.IsSuccessStatusCode) {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}