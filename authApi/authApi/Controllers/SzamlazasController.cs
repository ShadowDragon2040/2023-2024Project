using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using authApi.DTOs;
using authApi.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        private readonly AuthContext _context;

        public SzamlazasController(AuthContext context)
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

        [HttpPost]
        public async Task<IActionResult> Post(CreatedSzamlazasokDto createdSzamlazasokDto)
        {
            try
            {
                var request = new Szamlaza
                {
                    UserId = createdSzamlazasokDto.UserId,
                    TermekId = createdSzamlazasokDto.TermekId,
                    SzinHex = createdSzamlazasokDto.SzinHex,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false
                };

                _context.Szamlazas.Add(request);
                await _context.SaveChangesAsync();

                return Ok(); // Optionally, you can return a response or data
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Put(int Id, UpdateSzamlazasokDto updateSzamlazasokDto)
        {
            try
            {
                var existingSzamlazas = _context.Szamlazas.FirstOrDefault(x => x.SzamlazasId == Id);
               
                existingSzamlazas.UserId = updateSzamlazasokDto.UserId;
                existingSzamlazas.TermekId = updateSzamlazasokDto.TermekId;
                existingSzamlazas.VasarlasIdopontja = DateTime.Now;
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;
                existingSzamlazas.SzinHex = updateSzamlazasokDto.SzinHex;

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
