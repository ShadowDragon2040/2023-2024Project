using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        private readonly project_databaseContext _context;

        public FelhasznalokController(project_databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Felhasznalok.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _context.Felhasznalok.Where(x => x.FelhasznaloId == id).ToListAsync();
            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult<FelhasznalokDto>> Post(CreatedFelhasznalokDto createdFelhasznalokDto)
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
                await context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
        }

        [HttpPut("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Put(int id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingFelhasznalo = await context.Felhasznalok.FirstOrDefaultAsync(x => x.FelhasznaloId == id);

                if (existingFelhasznalo == null)
                {
                    return NotFound();
                }

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

                await context.SaveChangesAsync();
                return Ok();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingFelhasznalo = await _context.Felhasznalok.FirstOrDefaultAsync(x => x.FelhasznaloId == id);

            if (existingFelhasznalo == null)
            {
                return NotFound();
            }

            _context.Felhasznalok.Remove(existingFelhasznalo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
