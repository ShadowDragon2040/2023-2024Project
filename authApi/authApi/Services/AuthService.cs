using authApi.Datas;
using authApi.Models;
using authApi.Models.Dtos;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace authApi.Services
{
    public class AuthService : IAuth
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly AppDbContext dataBase;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, AppDbContext dataBase, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.dataBase = dataBase;
            this.userManager = userManager;
            this.roleManager = roleManager;
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



        //private readonly IJwtTokenGenerator jwtTokenGenerat;

        public async Task<string> Register(RegisterRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.UserName,
                NormalizedUserName = registrationRequestDto.UserName.ToUpper(),
                FullName = registrationRequestDto.FullName,
                Email = registrationRequestDto.Email,
                Age = registrationRequestDto.Age,
            };
            try
            {
                var result = await userManager.CreateAsync(user, registrationRequestDto.Password);
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
