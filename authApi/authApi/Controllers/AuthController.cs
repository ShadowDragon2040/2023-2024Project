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
        private readonly IConfiguration _configuration;
        private readonly AppDbContext dataBase;

        public AuthController(IAuth authService, UserManager<ApplicationUser> userManager, IConfiguration configuration, AppDbContext dataBase)
        {
            this.userManager = userManager;
            this.authService = authService;
            _configuration = configuration;
            this.dataBase = dataBase;
        }

        private void SaveVerificationCodeToDatabase(string email, int code)
        {
            var user = dataBase.AppUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                user.EmailCode = code;
                dataBase.SaveChanges();
            }
            else
            {
                throw new Exception($"User with email '{email}' not found.");
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var errorMessage = await authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(400, errorMessage);
            }

            // Registration successful, send verification email
            try
            {
                Random rand = new Random();
                int randomCode = rand.Next(1000, 10000);
                SaveVerificationCodeToDatabase(model.Email, randomCode);
                EmailService.SendVerificationMail(model.Email,randomCode, _configuration);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error occurred while sending verification email.");
            }

            return StatusCode(201, "Successful registration. Verification email has been sent.");
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