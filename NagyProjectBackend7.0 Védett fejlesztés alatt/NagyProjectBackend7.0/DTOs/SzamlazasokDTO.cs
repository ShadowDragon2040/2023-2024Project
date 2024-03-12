
using NagyProjectBackend7._0.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record SzamlazasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedSzamlazasokDto(int FelhasznaloId, int TermekId,int szinHex, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record UpdateSzamlazasokDto(Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
}
