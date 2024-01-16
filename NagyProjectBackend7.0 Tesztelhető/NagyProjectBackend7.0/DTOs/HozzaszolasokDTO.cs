using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record HozzaszolasokDto(int HozzaszolasId, int FelhasznaloId, int TermekId, string Leiras, int Ertekeles);
    public record CreatedHozzaszolasokDto(int HozzaszolasId, int FelhasznaloId, int TermekId, string Leiras, int Ertekeles);
    public record UpdateHozzaszolasokDto(int HozzaszolasId, int FelhasznaloId, int TermekId, string Leiras, int Ertekeles);
}
