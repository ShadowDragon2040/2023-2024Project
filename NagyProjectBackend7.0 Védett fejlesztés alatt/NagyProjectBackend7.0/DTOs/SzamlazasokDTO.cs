
using NagyProjectBackend7.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record SzamlazasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedSzamlazasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record UpdateSzamlazasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
}
