using ProjectBackend.Models;

namespace ProjectBackend.DTOs
{
    public record TermekekDto(int Id, string TermekNev, int Ar, string Leiras, int KategoriaId, int Menyiseg, string Keputvonal);
    public record CreatedTermekekDto(string TermekNev, int Ar, string Leiras, int KategoriaId,  int Menyiseg, string Keputvonal);
    public record UpdateTermekekDto(string TermekNev, int Ar, string Leiras, int KategoriaId, int Menyiseg, string Keputvonal);

    public record HozzaszolasAdatok(int HozzaszolasId, string Leiras, int Ertekeles, string UserId /*string UserName*/);

    public record TermekEgyoldalAdatokWithHozzaszolasok(int TermekId, string TermekNev, int Ar,string TermekLeiras,int Menyiseg,int KategoriaId,string Keputvonal,List<HozzaszolasAdatok> Hozzaszolasok);
}
