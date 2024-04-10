﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectBackend.DTOs;
using ProjectBackend.Models;
using ProjectBackend.DTOs;

namespace ProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Aspnetuser User = new Aspnetuser();
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
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User.UserName = request.UserName;
            User.PasswordHash = passwordHash;
            try
            {
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(User);

        }

        [HttpPost("login")]
        public ActionResult<Aspnetuser> Login(LoginRequestDto request)
        {
            if (User.UserName != request.UserName)
            {
                return BadRequest("User Not Found!");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, User.PasswordHash))
            {
                return BadRequest("Wrong password!");
            }

            string token = CreateToken(User);

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