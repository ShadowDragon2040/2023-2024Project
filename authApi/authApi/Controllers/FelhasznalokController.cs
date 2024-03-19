using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using authApi.Models;
using authApi.DTOs;

namespace authApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        private readonly AuthContext _context;

        public FelhasznalokController(AuthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Aspnetusers.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var result = await _context.Aspnetusers.Where(x => x.Id == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost/*, Authorize(Roles = "ADMIN")*/]
        public async Task<ActionResult<FelhasznalokDto>> Post(CreatedFelhasznalokDto createdFelhasznalokDto)
        {
            try
            {
                var request = new Felhasznalok
                {
                    LoginNev = createdFelhasznalokDto.LoginNev,
                    Hash = createdFelhasznalokDto.Hash,
                    Nev = createdFelhasznalokDto.Nev,
                    Jog = createdFelhasznalokDto.Jog,
                    Email = createdFelhasznalokDto.Email,
                    ProfilKep = createdFelhasznalokDto.ProfilKep
                };

                _context.Aspnetusers.Add(request);
                await _context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")/*, Authorize(Roles = "ADMIN")*/]
        public async Task<ActionResult> Put(string id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            try
            {
                var existingFelhasznalo = await _context.Aspnetusers.FirstOrDefaultAsync(x => x.Id == id);

                if (existingFelhasznalo == null)
                {
                    return NotFound();
                }

                existingFelhasznalo.LoginNev = updateFelhasznalokDto.LoginNev;
                existingFelhasznalo.Hash = updateFelhasznalokDto.Hash;
                existingFelhasznalo.Nev = updateFelhasznalokDto.Nev;
                existingFelhasznalo.Jog = updateFelhasznalokDto.Jog;
                existingFelhasznalo.Email = updateFelhasznalokDto.Email;
                existingFelhasznalo.ProfilKep = updateFelhasznalokDto.ProfilKep;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")/*, Authorize(Roles = "ADMIN")*/]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var existingFelhasznalo = await _context.Aspnetusers.FirstOrDefaultAsync(x => x.Id == id);

                _context.Aspnetusers.Remove(existingFelhasznalo);
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
