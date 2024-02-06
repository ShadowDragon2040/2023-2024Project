using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        private readonly project_databaseContext _context;

        public TermekekController(project_databaseContext context)
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

        [HttpGet("/Tagek")/*, Authorize*/]
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

        [HttpGet("{id}")/*, Authorize*/]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Termekek.Where(x => x.TermekId == id).ToListAsync();
                return Ok(result);
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
                    SzinId = createdTermekekDto.SzinId,
                    TagId = createdTermekekDto.TagId,
                    Keputvonal = createdTermekekDto.Keputvonal,
                };

                _context.Termekek.Add(request);
                _context.SaveChanges();

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
                existingTermek.SzinId = updateTermekedDto.SzinId;
                existingTermek.TagId = updateTermekedDto.TagId;
                existingTermek.Keputvonal = updateTermekedDto.Keputvonal;

                _context.Termekek.Update(existingTermek);
                _context.SaveChanges();
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
