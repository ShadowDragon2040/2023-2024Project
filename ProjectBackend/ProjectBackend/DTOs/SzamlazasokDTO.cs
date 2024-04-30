
using ProjectBackend.Models;

namespace ProjectBackend.DTOs
{
    public record SzamlazasokDto(int Id, Aspnetuser UserId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedSzamlazasokDto(string UserId, int TermekId, int Darab, string SzinHex);
    public record UpdateSzamlazasokDto(string UserId, int TermekId, int Darab, string SzinHex, bool SikeresSzalitas);
}
