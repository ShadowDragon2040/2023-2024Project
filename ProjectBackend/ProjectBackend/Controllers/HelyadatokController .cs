using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.DTOs;
using ProjectBackend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelyadatokController : ControllerBase
    {
        private readonly AuthContext _context;

        public HelyadatokController(AuthContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Helyadatok.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //userId alapján
        [HttpGet("{id}"), Authorize(Roles = "USER,ADMIN")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var result = await _context.Helyadatok.Where(x => x.UserId == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> Post(CreatedHelyadatokDto createdHelyadatokDto)
        {
            try
            {
                var request = new Helyadatok
                {
                    UserId = createdHelyadatokDto.UserId,
                    OrszagNev = createdHelyadatokDto.OrszagNev,
                    VarosNev = createdHelyadatokDto.VarosNev,
                    UtcaNev = createdHelyadatokDto.UtcaNev,
                    Iranyitoszam = createdHelyadatokDto.Iranyitoszam,
                    Hazszam = createdHelyadatokDto.Hazszam,
                    Egyeb = createdHelyadatokDto.Egyeb,
                };

                _context.Helyadatok.Add(request);
                await _context.SaveChangesAsync();

                return Ok(); // Optionally, you can return a response or data
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Put(int id, UpdateHelyadatokDto updateHelyadatokDto)
        {
            try
            {
                var existingHelyadatoks = await _context.Helyadatok.FindAsync(id);
                if (existingHelyadatoks == null)
                    return NotFound();

                existingHelyadatoks.UserId = updateHelyadatokDto.UserId;
                existingHelyadatoks.OrszagNev = updateHelyadatokDto.OrszagNev;
                existingHelyadatoks.VarosNev = updateHelyadatokDto.VarosNev;
                existingHelyadatoks.UtcaNev = updateHelyadatokDto.UtcaNev;
                existingHelyadatoks.Iranyitoszam = updateHelyadatokDto.Iranyitoszam;
                existingHelyadatoks.Hazszam = updateHelyadatokDto.Hazszam;
                existingHelyadatoks.Egyeb = updateHelyadatokDto.Egyeb;

                _context.Helyadatok.Update(existingHelyadatoks);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingHelyadatoks = await _context.Helyadatok.FindAsync(id);
                if (existingHelyadatoks == null)
                    return NotFound();

                _context.Helyadatok.Remove(existingHelyadatoks);
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
