using authApi.Models.Dtos;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace authApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuth authService;
        public AuthController(IAuth authService)
        {
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
            return StatusCode(201, "Sikeres Regisztráció.");
        }

        [HttpPost("AssignRole")]
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