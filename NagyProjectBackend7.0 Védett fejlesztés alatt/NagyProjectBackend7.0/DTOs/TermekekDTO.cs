using NagyProjectBackend7._0.Models;
namespace Webárúház_Nagy_Project.DTOs
{
    public record TermekekDto(int Id, string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);
    public record CreatedTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);
    public record UpdateTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);
}
