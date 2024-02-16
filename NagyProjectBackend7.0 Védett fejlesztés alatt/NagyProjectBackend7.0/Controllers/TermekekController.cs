using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webárúház_Nagy_Project.DTOs;
using NagyProjectBackend7._0.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public TermekekController(ProjectDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet/*, Authorize*/]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Termekek.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Kategoriak")/*, Authorize*/]
        public async Task<ActionResult> GetKategoriak()
        {
            try
            {
                var result = await _context.Kategoriak.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Termek/{kategoriaId}")/*, Authorize*/]
        public async Task<ActionResult<IEnumerable<Termekek>>> GetTermekByKategoriaId(int kategoriaId)
        {
            try
            {
                // Retrieve all termekek with the given kategoriaId
                var termekekList = await _context.Termekek
                    .Where(t => t.KategoriaId == kategoriaId)
                    .ToListAsync();

                // Check if there are any termekek found
                if (termekekList.Count == 0)
                {
                    return NotFound("No termekek found for the given kategoriaId.");
                }

                return Ok(termekekList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpGet("/Tagek"), Authorize]
        public async Task<ActionResult> GetTagek()
        {
            try
            {
                var result = await _context.Tagek.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        [HttpGet("EgyTermek/{id}")/*, Authorize*/]
        public async Task<ActionResult<TermekEgyoldalAdatokWithHozzaszolasok>> Get(int id)
        {
            try
            {
                // Retrieve the termek with the given id
                var termek = await _context.Termekek.FindAsync(id);
                if (termek == null)
                {
                    return NotFound();
                }

                // Retrieve all hozzaszolas associated with the termek
                var hozzaszolasList = await _context.Hozzaszolasok
                    .Where(h => h.TermekId == id)
                    .Select(h => new HozzaszolasAdatok(
                        h.HozzaszolasId,
                        h.Leiras,
                        h.Ertekeles,
                        h.FelhasznaloId,
                        h.Felhasznalo.LoginNev
                    ))
                    .ToListAsync();

                // Construct the final DTO containing termek and hozzaszolas data
                var termekEgyoldalAdatokWithHozzaszolasok = new TermekEgyoldalAdatokWithHozzaszolasok(
                    termek.TermekId,
                    termek.Ar,
                    termek.Leiras,
                    termek.Menyiseg,
                    termek.KategoriaId,
                    termek.Keputvonal,
                    hozzaszolasList
                );

                return Ok(termekEgyoldalAdatokWithHozzaszolasok);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult<TermekekDto>> Post(CreatedTermekekDto createdTermekekDto)
        {
            try
            {
                var request = new Termekek
                {
                    TermekNev = createdTermekekDto.TermekNev,
                    Leiras = createdTermekekDto.Leiras,
                    Menyiseg = createdTermekekDto.Menyiseg,
                    Keputvonal = createdTermekekDto.Keputvonal,
                };

                _context.Termekek.Add(request);
                await _context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Put(int id, UpdateTermekekDto updateTermekedDto)
        {
            try
            {
                var existingTermek = _context.Termekek.FirstOrDefault(x => x.TermekId == id);

                existingTermek.TermekNev = updateTermekedDto.TermekNev;
                existingTermek.Leiras = updateTermekedDto.Leiras;
                existingTermek.Menyiseg = updateTermekedDto.Menyiseg;
                existingTermek.Keputvonal = updateTermekedDto.Keputvonal;

                _context.Termekek.Update(existingTermek);
               await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingTermek = _context.Termekek.FirstOrDefault(x => x.TermekId == id);

                _context.Termekek.Remove(existingTermek);
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
