using authApi.Datas;
using authApi.Models;
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
using authApi.DTOs;

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
            var token = jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Id = user.Id,
                UserName = user.UserName
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

        
        public async Task<string> Register(RegisterRequestDto registerRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName =registerRequestDto.UserName,
                NormalizedUserName =registerRequestDto.UserName.ToUpper(),
                Email =registerRequestDto.Email
            };
            try
            {
                var result = await userManager.CreateAsync(user,registerRequestDto.Password);
                //role táblába berakja a USER-t
                roleManager.CreateAsync(new IdentityRole("USER")).GetAwaiter().GetResult();
                //kapcsoló táblába be kell rakni a kapcsolatot
                // nincs még itt
                Random rand = new Random();
                int randomCode = rand.Next(1000, 10000);
                SaveVerificationCodeToDatabase(registerRequestDto.Email, randomCode);
                EmailService.SendVerificationMail(registerRequestDto.Email, randomCode, _configuration);
                

                if (result.Succeeded)
                {
                    var userToReturn = dataBase.AppUsers.First(user => user.UserName ==registerRequestDto.UserName);

                    UserDto userDto = new()
                    {
                        Id = userToReturn.Id,
                        Email = userToReturn.Email,
                        UserName = userToReturn.UserName
                    };
                    
                    return "";
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
    }
}
