using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        private readonly project_databaseContext _context;

        public SzamlazasController(project_databaseContext context)
        {
            _context = context;
        }

        [HttpGet/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Szamlazasok.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")/*, Authorize(Roles = "Admin")*/]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Szamlazasok.Where(x => x.SzamlazasId == id).ToListAsync();
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
                var request = new Szamlazasok
                {
                    Felhasznalok = createdSzamlazasokDto.FelhasznaloId,
                    Termekek = createdSzamlazasokDto.TermekId,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false,
                };

                _context.Szamlazasok.Add(request);
                _context.SaveChanges();

                return Ok(/*request.AsDto()*/);
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
                var existingSzamlazas = _context.Szamlazasok.FirstOrDefault(x => x.SzamlazasId == Id);

                /*existingSzamlazas.VasarlasIdopontja = updateSzamlazasokDto.VasarlasIdopontja;*/
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;

                _context.Szamlazasok.Update(existingSzamlazas);
                _context.SaveChanges();
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
                var existingSzamlazas = _context.Szamlazasok.FirstOrDefault(x => x.SzamlazasId == id);

                _context.Szamlazasok.Remove(existingSzamlazas);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
