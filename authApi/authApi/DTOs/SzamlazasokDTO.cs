
using authApi.Models;

namespace authApi.DTOs
{
    public record SzamlazasokDto(int Id, Aspnetuser UserId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedSzamlazasokDto(Aspnetuser UserId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record UpdateSzamlazasokDto(Aspnetuser UserId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
}
