using authApi.Datas;
using authApi.Models;
using authApi.Models.Dtos;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace authApi.Services
{
    public class AuthService : IAuth
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly AppDbContext dataBase;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, AppDbContext dataBase, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.dataBase = dataBase;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await dataBase.AppUsers.FirstOrDefaultAsync(user => user.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = ""};
            }

            var roles = await userManager.GetRolesAsync(user);
            var token = jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDto = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName
            };
            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = dataBase.AppUsers.FirstOrDefault(user => user.Email.ToLower() == email.ToLower()); 
            if (user != null)
            {
                if (!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //itt adjuk meg a felhsználókhoz a szerepköröket
                    roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
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

        public async Task<string> Register(RegisterRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.UserName,
                NormalizedUserName = registrationRequestDto.UserName.ToUpper(),
                Email = registrationRequestDto.Email,
            };
            try
            {
                var result = await userManager.CreateAsync(user, registrationRequestDto.Password);

                Random rand = new Random();
                int randomCode = rand.Next(1000, 10000);
                SaveVerificationCodeToDatabase(registrationRequestDto.Email, randomCode);
                EmailService.SendVerificationMail(registrationRequestDto.Email, randomCode, _configuration);

                if (result.Succeeded)
                {
                    var userToReturn = dataBase.AppUsers.First(user => user.UserName == registrationRequestDto.UserName);

                    UserDto userDto = new()
                    {
                        Id = userToReturn.Id,
                        Email = userToReturn.Email,
                        UserName = userToReturn.UserName,
                        FullName = userToReturn.FullName,
                        Age = userToReturn.Age,
                    };
                    return userDto.FullName;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /*
        public async Task<IActionResult> VerifyEmailCode(VerificationRequestDto model)
        {
            var user = dataBase.AppUsers.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());

            if (user == null)
            {
                return NotFound("User not found.");
            }
            if (user.EmailCode == model.EmailCode)
            {
                return Ok("Email code verified successfully.");
            }
            else
            {
                return BadRequest("Invalid email code.");
            }
        }
        */
    }
}
