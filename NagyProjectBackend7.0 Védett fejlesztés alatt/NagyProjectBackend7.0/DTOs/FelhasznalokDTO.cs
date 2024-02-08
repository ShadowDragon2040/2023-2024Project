using NagyProjectBackend7.Models;

namespace Webárúház_Nagy_Project.DTOs
{
    public record FelhasznalokDto(int Id, string LoginNev, string Hash, string Salt, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep, Orszagok OrszágKod, Varosok VarosNev, string UtcaNev, string IranyitoSzam, int Hazszam);
    public record CreatedFelhasznalokDto(string LoginNev, string Hash, string Salt, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep, Orszagok OrszágKod, Varosok VarosNev, string UtcaNev, string IranyitoSzam, int Hazszam);
    public record UpdateFelhasznalokDto(string LoginNev, string Hash, string Salt, string Nev, int Jog, bool Aktivalva, string Email, string ProfilKep, Orszagok OrszágKod, Varosok VarosNev, string UtcaNev, string IranyitoSzam, int Hazszam);

    public class UserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}