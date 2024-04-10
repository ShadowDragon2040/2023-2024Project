﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectBackend.DTOs;
using ProjectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using authApi.Models;

namespace ProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static Random rnd = new Random();
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
                    EmailCode = rnd.Next(1000, 10000),
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
            var user = _authContext.Aspnetuser.FirstOrDefault(u => u.UserName == request.UserName);
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
        [HttpPost("AssignRole")]
        [Authorize(Roles = "USER")] // Change the role as per your requirement
        public async Task<ActionResult> AssignRole([FromBody] AssignRoleDto model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Role))
            {
                return BadRequest("Invalid model or missing fields.");
            }

            var user = _authContext.Aspnetuser.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());
            if (user != null)
            {
                var role = _authContext.Aspnetrole.FirstOrDefault(r => r.Name.ToLower() == model.Role.ToLower());
                if (role != null)
                {
                    var userRole = _authContext.Aspnetuserrole.FirstOrDefault(ur => ur.UserId == user.Id && ur.RoleId == role.Id);
                    if (userRole != null)
                    {
                        // Update the user's role
                        userRole.RoleId = role.Id;
                        await _authContext.SaveChangesAsync();
                        return Ok("User role updated successfully.");
                    }
                    else
                    {
                        // Assign the role to the user
                        var userRoleToAdd = new Aspnetuserrole()
                        {
                            UserId = user.Id,
                            RoleId = role.Id
                        };
                        _authContext.Aspnetuserrole.Update(userRoleToAdd);
                        await _authContext.SaveChangesAsync();
                        return Ok("User role assigned successfully.");
                    }
                }
                else
                {
                    // Create the role and assign it to the user
                    var newRole = new Aspnetrole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Role
                    };
                    _authContext.Aspnetrole.Add(newRole);

                    var userRoleToAdd = new Aspnetuserrole()
                    {
                        UserId = user.Id,
                        RoleId = newRole.Id
                    };
                    _authContext.Aspnetuserrole.Update(userRoleToAdd);

                    await _authContext.SaveChangesAsync();
                    return Ok($"Role '{model.Role}' created and assigned to the user successfully.");
                }
            }
            else
            {
                return BadRequest("User not found.");
            }
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
                issuer: _configuration.GetSection("AuthSettings:JwtOptions:Issuer").Value!,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}