using ProjectBackend.Models;

namespace ProjectBackend.DTOs
{
    public record HelyadatokDto(
        int Id,
        string UserId,
        string OrszagNev,
        string VarosNev,
        string UtcaNev,
        string Iranyitoszam,
        string Hazszam,
        string Egyeb
    );

    public record CreatedHelyadatokDto(
        string UserId,
        string OrszagNev,
        string VarosNev,
        string UtcaNev,
        string Iranyitoszam,
        string Hazszam,
        string Egyeb
    );

    public record UpdateHelyadatokDto(
        string UserId,
        string OrszagNev,
        string VarosNev,
        string UtcaNev,
        string Iranyitoszam,
        string Hazszam,
        string Egyeb
    );
}
