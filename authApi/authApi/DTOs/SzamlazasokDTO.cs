
using authApi.Models;

namespace authApi.DTOs
{
    public record SzamlazasokDto(int Id, Aspnetuser UserId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedSzamlazasokDto(string UserId, int TermekId ,int SzinHex);
    public record UpdateSzamlazasokDto(string UserId, int TermekId,int SzinHex, bool SikeresSzalitas);
}
