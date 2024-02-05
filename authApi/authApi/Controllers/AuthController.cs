using authApi.Models.Dtos;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using authApi.Services;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using authApi.Models;

namespace authApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuth authService;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthController(IAuth authService, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.authService = authService;
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmEmail(string email, string hash)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(email));
                    var calculatedHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                    if (calculatedHash.Equals(hash, StringComparison.OrdinalIgnoreCase))
                    {
                        var user = await userManager.FindByEmailAsync(email);

                        if (user != null && !user.EmailConfirmed)
                        {
                            user.EmailConfirmed = true;
                            await userManager.UpdateAsync(user);
                        }
                        else
                        {
                            return BadRequest("Email is already confirmed or user not found.");
                        }
                    }
                    else
                    {
                        return BadRequest("Invalid email verification link.");
                    }
                }

                EmailService.SendMail(email, "Sikeres regisztráció", $"Ön sikeresen regisztrált a PrintFusion oldalra mostantól az oldal összes funkciója elérhető!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Email verified successfully!");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var errorMessage = await authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(400, errorMessage);
            }
            return StatusCode(201, "Sikeres Regisztráció.");
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignRole([FromBody] AssignRoleDto model)
        {
            var assignedRoleSuccesful = await authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignedRoleSuccesful)
            {
                return BadRequest();
            }
            return StatusCode(200, "Sikeresen hozzá lett adva a felhasználóhoz a role");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await authService.Login(model);

            if (loginResponse.User == null)
            {
                return BadRequest("Nem megfelelő felhasználónév vagy jelszó!");
            }
            return StatusCode(200, loginResponse);
        }

    }
}