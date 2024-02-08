using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Webárúház_Nagy_Project.DTOs;
using NagyProjectBackend7.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public FelhasznalokController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Felhasznalok.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Felhasznalok.Where(x => x.FelhasznaloId == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult<FelhasznalokDto>> Post(CreatedFelhasznalokDto createdFelhasznalokDto)
        {
            try
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

                _context.Felhasznalok.Add(request);
                await _context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Put(int id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            try
            {
                var existingFelhasznalo = await _context.Felhasznalok.FirstOrDefaultAsync(x => x.FelhasznaloId == id);

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

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingFelhasznalo = await _context.Felhasznalok.FirstOrDefaultAsync(x => x.FelhasznaloId == id);

                _context.Felhasznalok.Remove(existingFelhasznalo);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
