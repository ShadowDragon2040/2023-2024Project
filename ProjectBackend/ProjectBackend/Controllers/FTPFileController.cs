using ProjectBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ProjectBackend.Controllers
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

        [HttpGet, Authorize(Roles ="ADMIN")]
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

        [HttpPost,Authorize(Roles ="ADMIN")]
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
