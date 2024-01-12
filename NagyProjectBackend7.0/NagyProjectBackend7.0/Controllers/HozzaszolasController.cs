using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HozzaszolasController : ControllerBase
    {
        [HttpGet, Authorize]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Hozzaszolasok.ToList());
            }
        }

        [HttpGet("{id}"), Authorize]
        public ActionResult Get(int id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Hozzaszolasok.Where(x => x.HozzaszolasId == id);
                return Ok(result);
            }
        }

        [HttpPost, Authorize]
        public ActionResult<HozzaszolasokDto> Post(CreatedHozzaszolasokDto createdHozzaszolasokDto)
        {
            using (var context = new project_databaseContext())
            {

                var request = new Hozzaszolasok
                {
                    Felhasznalok = createdHozzaszolasokDto.FelhasznaloId,
                    Termekek = createdHozzaszolasokDto.TermekId,
                };

                context.Hozzaszolasok.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        /*
         * Ennek a végpontnak nincs értelme
        [HttpPut("{id}")]
        public ActionResult Put(int Id, UpdateHozzaszolasokDto updateHozzaszolasokDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingHozzaszolas = context.Hozzaszolasok.FirstOrDefault(x => x.Id == Id);

                existingHozzaszolas.VasarlasIdopontja = updateHozzaszolasokDto.VasarlasIdopontja;
                existingHozzaszolas.SikeresSzalitas = updateHozzaszolasokDto.SikeresSzalitas;

                context.Hozzaszolasok.Update(existingHozzaszolas);
                context.SaveChanges();
                return Ok();
            }
        }
        */

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            using (var context = new project_databaseContext())
            {
                var existingHozzaszolas = context.Hozzaszolasok.FirstOrDefault(x => x.HozzaszolasId == id);

                context.Hozzaszolasok.Remove(existingHozzaszolas);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
