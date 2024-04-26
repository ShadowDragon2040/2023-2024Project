using ProjectBackend.DTOs;

namespace ProjectBackend.DTOs
{
    public record FelhasznalokDto(string Id, string UserName, string PasswordHash, bool EmailConfirmed, string Email, string ProfilKep);
    public record CreatedFelhasznalokDto(string UserName, string PasswordHash, bool EmailConfirmed, string Email, string ProfilKep);
    public record UpdateFelhasznalokDto(string UserName, string PasswordHash, bool EmailConfirmed, string Email, string ProfilKep);
}