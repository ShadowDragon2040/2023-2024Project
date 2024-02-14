using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumController : ControllerBase
    {

        [HttpGet("{a},{b}")]
        public JsonResult Sum(double a ,double b)
        {
            return new JsonResult(a+b);
        }
    }
}
