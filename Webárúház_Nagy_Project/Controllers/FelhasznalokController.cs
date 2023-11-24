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
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Felhasznalok.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Felhasznalok.Where(x => x.Id == id);
                return Ok(result);
            }
        }

        [HttpPost]
        public ActionResult<FelhasznalokDto> Post(CreatedFelhasznalokDto createdFelhasznalokDto)
        {
            using (var context = new project_databaseContext())
            {
                
                var request = new Felhasznalok
                {
                    Id = Guid.NewGuid(),
                    LoginNev = createdFelhasznalokDto.LoginNev,
                    Hash = createdFelhasznalokDto.Hash,
                    Salt = createdFelhasznalokDto.Salt,
                    Nev = createdFelhasznalokDto.Nev,
                    Jog = createdFelhasznalokDto.Jog,
                    Aktivalva = createdFelhasznalokDto.Aktivalva,
                    Email = createdFelhasznalokDto.Email,
                    ProfilKep = createdFelhasznalokDto.ProfilKep,
                    OrszágKod = createdFelhasznalokDto.OrszágKod,
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

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingFelhasznalo = context.Felhasznalok.FirstOrDefault(x => x.Id == id);

                existingFelhasznalo.LoginNev = updateFelhasznalokDto.LoginNev;
                existingFelhasznalo.Hash = updateFelhasznalokDto.Hash;
                existingFelhasznalo.Salt = updateFelhasznalokDto.Salt;
                existingFelhasznalo.Nev = updateFelhasznalokDto.Nev;
                existingFelhasznalo.Jog = updateFelhasznalokDto.Jog;
                existingFelhasznalo.Aktivalva = updateFelhasznalokDto.Aktivalva;
                existingFelhasznalo.Email = updateFelhasznalokDto.Email;
                existingFelhasznalo.ProfilKep = updateFelhasznalokDto.ProfilKep;
                    existingFelhasznalo.OrszágKod = updateFelhasznalokDto.OrszágKod;
                existingFelhasznalo.VarosNev = updateFelhasznalokDto.VarosNev;
                existingFelhasznalo.UtcaNev = updateFelhasznalokDto.UtcaNev;
                existingFelhasznalo.IranyitoSzam = updateFelhasznalokDto.IranyitoSzam;
                existingFelhasznalo.Hazszam = updateFelhasznalokDto.Hazszam;

                context.Felhasznalok.Update(existingFelhasznalo);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            using (var context = new project_databaseContext())
            {
                var existingFelhasznalo = context.Felhasznalok.FirstOrDefault(x => x.Id == id);

                context.Felhasznalok.Remove(existingFelhasznalo);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
