using authApi.Models.Dtos;

namespace authApi.Services.IServices
{
    public interface IAuth
    {
        Task<string> Register(RegisterRequestDto registrationRequestDto);

        Task<bool> AssignRole(string email, string roleName);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
