using ProjectBackend.Models;

namespace ProjectBackend.DTOs
{
    public record HozzaszolasokDto(int HozzaszolasId, Aspnetuser UserId, int TermekId, string Leiras, int Ertekeles);
    public record CreatedHozzaszolasokDto(string UserId, int TermekId, string Leiras, int Ertekeles);
    public record UpdateHozzaszolasokDto(string Leiras, int Ertekeles);
}
