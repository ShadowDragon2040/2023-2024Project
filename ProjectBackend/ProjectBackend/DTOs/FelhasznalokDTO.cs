using ProjectBackend.DTOs;

namespace ProjectBackend.DTOs
{
    public record FelhasznalokDto(string Id, string UserName, string PasswordHash, bool EmailConfirmed, string Email, byte[] ProfilKep);
    public record CreatedFelhasznalokDto(string UserName, string PasswordHash, bool EmailConfirmed, string Email, byte[] ProfilKep);
    public record UpdateFelhasznalokDto(string UserName, string PasswordHash, bool EmailConfirmed, string Email, byte[] ProfilKep);
}