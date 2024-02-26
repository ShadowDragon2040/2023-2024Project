using authApi.Models.Dtos;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using authApi.Services;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using authApi.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using authApi.Datas;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var errorMessage = await authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(400, errorMessage);
            }

            return Ok();
        }

        /*
        [HttpPost("verify-email")]
        public async Task<ActionResult> VerifyEmailCode([FromBody] VerificationRequestDto model)
        {
            var result = await authService.VerifyEmailCode(model);

            if (result is OkResult)
            {
                var assignedRoleSuccesful = await authService.AssignRole(model.Email, model.Role.ToUpper());

                if (assignedRoleSuccesful)
                {
                    return Ok("Email code verified successfully and role assigned.");
                }
                else
                {
                    return StatusCode(500, "Error assigning role.");
                }
            }
            else
            {
                return result;
            }
        }
        */

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