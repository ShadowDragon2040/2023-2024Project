using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.Models;
using Webárúház_Nagy_Project.DTOs;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Bejelenkezes : Controller
    {
        public static Felhasznalok user = new Felhasznalok();
        private readonly IConfiguration  _configuration;

        public Bejelenkezes(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public ActionResult<Felhasznalok> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.LoginNev = request.Username;
            user.Hash = request.Password;
            
            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult<Felhasznalok> Login(UserDto request)
        {
            if (user.LoginNev != request.Username)
            {
                return BadRequest("Ilyen nevű felhasználó nincsen.");

            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Hash))
            {
                return BadRequest("Rossz jelszó.");
            }
            string token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(Felhasznalok user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.LoginNev)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
