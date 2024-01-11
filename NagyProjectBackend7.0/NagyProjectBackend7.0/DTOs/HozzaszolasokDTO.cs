using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record HozzaszolasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record CreatedHozzaszolasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
    public record UpdateHozzaszolasokDto(int Id, Felhasznalok FelhasznaloId, Termekek TermekId, DateTime VasarlasIdopontja, bool SikeresSzalitas);
}
