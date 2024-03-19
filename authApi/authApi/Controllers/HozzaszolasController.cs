﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authApi.DTOs;
using authApi.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HozzaszolasController : ControllerBase
    {
        private readonly AuthContext _context;

        public HozzaszolasController(AuthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Hozzaszolasok>> Get()
        {
            try
            {
                var result = await _context.Hozzaszolasok.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("termek/{termekId}")] 
        public async Task<ActionResult<Hozzaszolasok>> GetByTermekId(int termekId)
        {
            try
            {
                var result = await _context.Hozzaszolasok.Where(f => f.TermekId == termekId).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hozzaszolasok>> Get(int id)
        {
            try
            {
                var result = await _context.Hozzaszolasok.Where(x => x.HozzaszolasId == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<HozzaszolasokDto>> Post(CreatedHozzaszolasokDto createdHozzaszolasokDto)
        {
            try
            {
                var request = new Hozzaszolasok
                {
                    UserId = createdHozzaszolasokDto.UserId,
                    TermekId = createdHozzaszolasokDto.TermekId,
                    Leiras = createdHozzaszolasokDto.Leiras,
                    Ertekeles = createdHozzaszolasokDto.Ertekeles
                };

                _context.Hozzaszolasok.Add(request);
                await _context.SaveChangesAsync();

                return Ok(/*request.AsDto()*/);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateHozzaszolasokDto updateHozzaszolasokDto)
        {
            try
            {
                var existingHozzaszolas = await _context.Hozzaszolasok.FirstOrDefaultAsync(x => x.HozzaszolasId == id);

                if (existingHozzaszolas == null)
                {
                    return NotFound(); // Or another appropriate response if the resource is not found
                }

                existingHozzaszolas.Leiras = updateHozzaszolasokDto.Leiras;
                existingHozzaszolas.Ertekeles = updateHozzaszolasokDto.Ertekeles;

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
                var existingHozzaszolas = await _context.Hozzaszolasok.FirstOrDefaultAsync(x => x.HozzaszolasId == id);

                 _context.Hozzaszolasok.Remove(existingHozzaszolas);
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