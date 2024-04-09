using authApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FTPFileController : ControllerBase
    {
        private readonly AuthContext _context;

        public FTPFileController(AuthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Ftpfile.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Ftpfile postFile)
        {
            try
            {
                _context.Add<Ftpfile>(postFile);
                _context.SaveChanges();
                return  Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
