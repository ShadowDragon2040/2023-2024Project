using authApi.Models;

namespace authApi.DTOs
{
    public record FelhasznalokDto(int Id, string LoginNev, string Hash, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep);
    public record CreatedFelhasznalokDto(string LoginNev, string Hash, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep);
    public record UpdateFelhasznalokDto(string LoginNev, string Hash, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep);
}