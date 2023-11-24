using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record TermekekDto(Guid Id, string TermekNev, int Ar, string Leiras, int Menyiseg, Szinek Szin, Tagek Tag, string Keputvonal);
    public record CreatedTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, Szinek Szin, Tagek Tag, string Keputvonal);
    public record UpdateTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, Szinek Szin, Tagek Tag, string Keputvonal);
}
