using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectBackend.DTOs;
using ProjectBackend.Models;

namespace ProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static Random rnd= new Random();    
        private readonly IConfiguration _configuration;
        AuthContext _authContext;

        public AuthController(IConfiguration configuration, AuthContext authContext)
        {
            _configuration = configuration;
            _authContext = authContext;
        }
        [HttpPost("register")]
        public ActionResult<Aspnetuser> Register(RegisterRequestDto request)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var newUser = new Aspnetuser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    PasswordHash = passwordHash,
                    Email = request.Email,
                    EmailCode = new Random().Next(1000, 10000),
                    AktivalasIdopotja = DateTime.Now,
                    EmailConfirmed = false,
                    ProfilKep = new byte[0]
                };

                _authContext.Aspnetuser.Add(newUser);
                _authContext.SaveChanges();

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<Aspnetuser> Login(LoginRequestDto request)
        {
            var user = _authContext.Aspnetuser.FirstOrDefault(u=>u.UserName==request.UserName);
            if (user.UserName != request.UserName)
            {
                return BadRequest("User Not Found!");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password!");
            }

            string token = CreateToken(user);

            return Ok(token);

        }

        private string CreateToken(Aspnetuser User)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Role,"USER")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                audience: _configuration.GetSection("AuthSettings:JwtOptions:Audience").Value!,
                issuer:_configuration.GetSection("AuthSettings:JwtOptions:Issuer").Value!,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}