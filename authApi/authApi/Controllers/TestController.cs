using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]  public ActionResult Index()
        {
            try
            {
                return Ok("xd");
            }
            catch ( Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
