using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.Models;
using ProjectBackend.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackend.Controllers
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

        [HttpGet ,Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _context.Aspnetuser.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}"), Authorize(Roles = "USER,ADMIN")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _context.Aspnetuser.Where(x => x.Id == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Put(string id, UpdateFelhasznalokDto updateFelhasznalokDto)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || updateFelhasznalokDto == null)
                {
                    return BadRequest("Invalid input");
                }

                var existingFelhasznalo = await _context.Aspnetuser.FirstOrDefaultAsync(x => x.Id == id);

                if (existingFelhasznalo == null)
                {
                    return NotFound();
                }

                existingFelhasznalo.UserName = updateFelhasznalokDto.UserName;
                existingFelhasznalo.PasswordHash = updateFelhasznalokDto.PasswordHash;
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

        [HttpDelete("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Invalid id");
                }

                var existingFelhasznalo = await _context.Aspnetuser.FirstOrDefaultAsync(x => x.Id == id);

                if (existingFelhasznalo == null)
                {
                    return NotFound();
                }

                _context.Aspnetuser.Remove(existingFelhasznalo);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
