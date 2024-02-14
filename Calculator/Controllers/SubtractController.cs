using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtractController : ControllerBase
    {
        [HttpGet("{a},{b}")]
        public JsonResult Subtract(double a, double b)
        {
            return new JsonResult(a - b);
        }
    }
}
