using AutomotivePartsOrdering.Service.Application;
using Microsoft.AspNetCore.Mvc;

namespace AutomotivePartsOrdering.Service.API {
    [Route("api/[controller]")]
    [ApiController]
    public class PartController(IPartService partService) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetPart([FromQuery] string brandCode, string partCode, int page, int pageSize) {

            var response = await partService.GetPartAsync(brandCode, partCode, page, pageSize);

            return Ok(response);
        }
    }
}