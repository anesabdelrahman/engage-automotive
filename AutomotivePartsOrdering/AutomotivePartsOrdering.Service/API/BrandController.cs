using AutomotivePartsOrdering.Service.Application;
using Microsoft.AspNetCore.Mvc;

namespace AutomotivePartsOrdering.Service.API {
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(IBrandService partService) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetPart([FromQuery] int page, int pageSize) {

            var response = await partService.GetBrandAsync(page, pageSize);
            
            if (response.IsSuccessStatusCode) {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}