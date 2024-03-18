using authApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace authApi.Services.IServices
{
    public interface IAuth
    {
        Task<string> Register(RegisterRequestDto registerRequestDto);

        Task<bool> AssignRole(string email, string roleName);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

    }
}
