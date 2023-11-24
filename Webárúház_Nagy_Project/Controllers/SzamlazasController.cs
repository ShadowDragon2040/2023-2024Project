﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Szamlazasok.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Szamlazasok.Where(x => x.Id == id);
                return Ok(result);
            }
        }

        [HttpPost]
        public ActionResult<SzamlazasokDto> Post(CreatedSzamlazasokDto createdSzamlazasokDto)
        {
            using (var context = new project_databaseContext())
            {

                var request = new Szamlazas
                {
                    Id = createdSzamlazasokDto.Id,
                    Felhasznalo = createdSzamlazasokDto.FelhasznaloId,
                    Termek = createdSzamlazasokDto.TermekId,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false,
                };

                context.Szamlazasok.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        /*
         * Ennek a végpontnak nincs értelme
        [HttpPut("{id}")]
        public ActionResult Put(int Id, UpdateSzamlazasokDto updateSzamlazasokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingSzamlazas = context.Szamlazasok.FirstOrDefault(x => x.Id == Id);

                existingSzamlazas.VasarlasIdopontja = updateSzamlazasokDto.VasarlasIdopontja;
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;

                context.Szamlazasok.Update(existingSzamlazas);
                context.SaveChanges();
                return Ok();
            }
        }
        */

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var context = new project_databaseContext())
            {
                var existingSzamlazas = context.Szamlazasok.FirstOrDefault(x => x.Id == id);

                context.Szamlazasok.Remove(existingSzamlazas);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
