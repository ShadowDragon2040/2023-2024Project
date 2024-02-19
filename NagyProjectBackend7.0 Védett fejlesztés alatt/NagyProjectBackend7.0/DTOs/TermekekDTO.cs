using NagyProjectBackend7._0.Models;
namespace Webárúház_Nagy_Project.DTOs
{
    public record TermekekDto(int Id, string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);
    public record CreatedTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);
    public record UpdateTermekekDto(string TermekNev, int Ar, string Leiras, int Menyiseg, int SzinId, string Keputvonal);

    public record HozzaszolasAdatok(int HozzaszolasId, string Leiras, int Ertekeles, int FelhasznaloId, string LoginNev);

    public record TermekEgyoldalAdatokWithHozzaszolasok(int TermekId, string TermekNev, int Ar,string TermekLeiras,int Menyiseg,int KategoriaId,string Keputvonal,List<HozzaszolasAdatok> Hozzaszolasok);
}
