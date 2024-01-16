﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        [HttpGet/*, Authorize(Roles = "Admin")*/]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Szamlazasok.ToList());
            }
        }

        [HttpGet("{id}")/*, Authorize(Roles = "Admin")*/]
        public ActionResult Get(int id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Szamlazasok.Where(x => x.SzamlazasId == id);
                return Ok(result);
            }
        }

        [HttpPost/*, Authorize(Roles = "Admin")*/]
        public ActionResult<SzamlazasokDto> Post(CreatedSzamlazasokDto createdSzamlazasokDto)
        {
            using (var context = new project_databaseContext())
            {

                var request = new Szamlazasok
                {
                    Felhasznalok = createdSzamlazasokDto.FelhasznaloId,
                    Termekek = createdSzamlazasokDto.TermekId,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false,
                };

                context.Szamlazasok.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        
        [HttpPut("{id}")/*, Authorize(Roles = "Admin")*/]
        public ActionResult Put(int Id, UpdateSzamlazasokDto updateSzamlazasokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingSzamlazas = context.Szamlazasok.FirstOrDefault(x => x.SzamlazasId == Id);

                /*existingSzamlazas.VasarlasIdopontja = updateSzamlazasokDto.VasarlasIdopontja;*/
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;

                context.Szamlazasok.Update(existingSzamlazas);
                context.SaveChanges();
                return Ok();
            }
        }
        

        [HttpDelete("{id}")/*, Authorize(Roles = "Admin")*/]
        public ActionResult Delete(int id)
        {
            using (var context = new project_databaseContext())
            {
                var existingSzamlazas = context.Szamlazasok.FirstOrDefault(x => x.SzamlazasId == id);

                context.Szamlazasok.Remove(existingSzamlazas);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
