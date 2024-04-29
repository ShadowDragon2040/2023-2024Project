using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectBackend.DTOs;
using ProjectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjectBackend.Services;
using static System.Net.WebRequestMethods;
namespace ProjectBackend.Controllers
{
    [Route("[controller]")]
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
        public IActionResult Register(RegisterRequestDto request)
        {
            try
            {
                // Validate request model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
                    ProfilKep = "http://printfusion.nhely.hu/test/ppp.jpg"
                };

                var userExists = _authContext.Aspnetuser.FirstOrDefault(user => user.UserName == newUser.UserName);
                var emailExists = _authContext.Aspnetuser.FirstOrDefault(email => email.Email == newUser.Email);
                var passExists = _authContext.Aspnetuser.FirstOrDefault(pass => pass.PasswordHash == newUser.PasswordHash);
                if (userExists != null)
                {
                    return BadRequest("User already exists with this username!");
                }
                if (emailExists!=null)
                {
                    return BadRequest("User already exists with this email address!");
                }
                if (passExists != null)
                {
                    return BadRequest("User already exists with this password!");
                }
                else
                {
                    var defaultRoleId= _authContext.Aspnetrole.FirstOrDefault(r=>r.Name=="USER");
                    Aspnetuserrole newuserrole = new Aspnetuserrole()
                    {
                        UserId=newUser.Id,
                        RoleId=defaultRoleId.Id

                    };
                    _authContext.Aspnetuserrole.Add(newuserrole);
                    _authContext.Aspnetuser.Add(newUser);
                    _authContext.SaveChanges();
                    // Send verification email
                    EmailService.SendVerificationMail(request.Email, newUser.EmailCode, _configuration);
                }

                return Ok("User registered successfully. Verification email sent.");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error registering user: {ex.Message}");

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public ActionResult Login(LoginRequestDto request)
        {
            var user = _authContext.Aspnetuser.FirstOrDefault(u => u.UserName == request.UserName);
            if (user == null)
            {
                return StatusCode(404,"User Not Found!");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return StatusCode(404,"Wrong password!");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        [HttpPost("updatepassword")]
        public IActionResult UpdatePassword(UpdatePasswordRequestDto request)
        {
            try
            {
                var user = _authContext.Aspnetuser.FirstOrDefault(u => u.Email == request.Email && u.EmailCode == request.EmailCode);
                if (user == null)
                {
                    return BadRequest("Invalid email or email code!");
                }

                if (string.IsNullOrEmpty(request.NewPassword))
                {
                    return BadRequest("New password is required!");
                }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
                _authContext.SaveChanges();

                // Optionally, you can send a confirmation email here
                EmailService.SendConfirmationMail(request.Email,$"Your new password is {request.NewPassword}",$"Your password was changed on the PrintFusion site, if this was not done by you contact us immediately!", _configuration);

                return Ok("Password updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating password: {ex.Message}");

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "ADMIN")] // Change the role as per your requirement
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

        [HttpPost("verify-email")]
        public IActionResult VerifyEmailCode([FromBody] VerificationRequestDto model)
        {
            try
            {
                var user = _authContext.Aspnetuser.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());

                if (user != null)
                {
                    if (user.EmailCode == model.EmailCode)
                    {
                        user.EmailConfirmed = true;
                        _authContext.Aspnetuser.Update(user);
                        _authContext.SaveChanges();

                        return Ok("Email verified successfully.");
                    }
                    else
                    {
                        return BadRequest("Incorrect email verification code.");
                    }
                }
                else
                {
                    return BadRequest("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying email: {ex.Message}");

                return StatusCode(500, "An error occurred while verifying email.");
            }
        }




        private string CreateToken(Aspnetuser User)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData,User.Id),
                new Claim(ClaimTypes.Name,User.UserName),
            };

            var userRole = _authContext.Aspnetuserrole.FirstOrDefault(userrole => userrole.UserId == User.Id);
            if (userRole != null)
            {
                var role = _authContext.Aspnetrole.FirstOrDefault(r => r.Id == userRole.RoleId);
                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "USER"));
            }

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