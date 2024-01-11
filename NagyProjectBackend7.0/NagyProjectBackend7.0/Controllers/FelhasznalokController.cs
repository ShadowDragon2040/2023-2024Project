using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        [HttpGet, Authorize]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Felhasznalok.ToList());
            }
        }

        [HttpGet("{id}"), Authorize]
        public ActionResult Get(int id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Felhasznalok.Where(x => x.FelhasznaloId == id);
                return Ok(result);
            }
        }

        [HttpPost, Authorize]
        public ActionResult<FelhasznalokDto> Post(CreatedFelhasznalokDto createdFelhasznalokDto)
        {
            using (var context = new project_databaseContext())
            {
                
                var request = new Felhasznalok
                {
                    LoginNev = createdFelhasznalokDto.LoginNev,
                    Hash = createdFelhasznalokDto.Hash,
                    Salt = createdFelhasznalokDto.Salt,
                    Nev = createdFelhasznalokDto.Nev,
                    Jog = createdFelhasznalokDto.Jog,
                    Aktivalva = createdFelhasznalokDto.Aktivalva,
                    Email = createdFelhasznalokDto.Email,
                    ProfilKep = createdFelhasznalokDto.ProfilKep,
                    OrszagKod = createdFelhasznalokDto.OrszágKod,
                    VarosNev = createdFelhasznalokDto.VarosNev,
                    UtcaNev = createdFelhasznalokDto.UtcaNev,
                    IranyitoSzam = createdFelhasznalokDto.IranyitoSzam,
                    Hazszam = createdFelhasznalokDto.Hazszam,
                };

                context.Felhasznalok.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        [HttpPut("{id}"), Authorize]
        public ActionResult Put(int id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingFelhasznalo = context.Felhasznalok.FirstOrDefault(x => x.FelhasznaloId == id);

                existingFelhasznalo.LoginNev = updateFelhasznalokDto.LoginNev;
                existingFelhasznalo.Hash = updateFelhasznalokDto.Hash;
                existingFelhasznalo.Salt = updateFelhasznalokDto.Salt;
                existingFelhasznalo.Nev = updateFelhasznalokDto.Nev;
                existingFelhasznalo.Jog = updateFelhasznalokDto.Jog;
                existingFelhasznalo.Aktivalva = updateFelhasznalokDto.Aktivalva;
                existingFelhasznalo.Email = updateFelhasznalokDto.Email;
                existingFelhasznalo.ProfilKep = updateFelhasznalokDto.ProfilKep;
                    existingFelhasznalo.OrszagKod = updateFelhasznalokDto.OrszágKod;
                existingFelhasznalo.VarosNev = updateFelhasznalokDto.VarosNev;
                existingFelhasznalo.UtcaNev = updateFelhasznalokDto.UtcaNev;
                existingFelhasznalo.IranyitoSzam = updateFelhasznalokDto.IranyitoSzam;
                existingFelhasznalo.Hazszam = updateFelhasznalokDto.Hazszam;

                context.Felhasznalok.Update(existingFelhasznalo);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}"), Authorize]
        public ActionResult Delete(int id)
        {
            using (var context = new project_databaseContext())
            {
                var existingFelhasznalo = context.Felhasznalok.FirstOrDefault(x => x.FelhasznaloId == id);

                context.Felhasznalok.Remove(existingFelhasznalo);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
