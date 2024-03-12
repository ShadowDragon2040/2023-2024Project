using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webárúház_Nagy_Project.DTOs;
using NagyProjectBackend7._0.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public SzamlazasController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet/*, Authorize(Roles = "ADMIN")*/]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Szamlazas.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")/*, Authorize(Roles = "ADMIN")*/]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Szamlazas.Where(x => x.SzamlazasId == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult<SzamlazasokDto>> Post(CreatedSzamlazasokDto createdSzamlazasokDto)
        {
            try
            {
                var request = new Szamlaza
                {
                    Felhasznalo = await _context.Felhasznalok.FindAsync(createdSzamlazasokDto.FelhasznaloId),
                    Termek = await _context.Termekek.FindAsync(createdSzamlazasokDto.TermekId),
                    SzinHex = createdSzamlazasokDto.szinHex,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false,
                };

                _context.Szamlazas.Add(request);
               await _context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateSzamlazasokDto updateSzamlazasokDto)
        {
            try
            {
                var existingSzamlazas = await _context.Szamlazas.FirstOrDefaultAsync(x => x.SzamlazasId == id);

                if (existingSzamlazas == null)
                {
                    return NotFound(); 
                }

                existingSzamlazas.Felhasznalo = await _context.Felhasznalok.FindAsync(updateSzamlazasokDto.FelhasznaloId);
                existingSzamlazas.Termek = await _context.Termekek.FindAsync(updateSzamlazasokDto.TermekId);
                existingSzamlazas.SzinHex = updateSzamlazasokDto.szinHex;
                existingSzamlazas.VasarlasIdopontja = updateSzamlazasokDto.VasarlasIdopontja;
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;

                _context.Szamlazas.Update(existingSzamlazas);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingSzamlazas = _context.Szamlazas.FirstOrDefault(x => x.SzamlazasId == id);

                _context.Szamlazas.Remove(existingSzamlazas);
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
