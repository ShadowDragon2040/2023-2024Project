using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        [HttpGet, Authorize]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Termekek.ToList());
            }
        }

        [HttpGet("{id}"), Authorize]
        public ActionResult Get(int id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Termekek.Where(x => x.TermekekId == id);
                return Ok(result);
            }
        }

        [HttpPost, Authorize]
        public ActionResult<TermekekDto> Post(CreatedTermekekDto createdTermekekDto)
        {
            using (var context = new project_databaseContext())
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

                context.Termekek.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        [HttpPut("{id}"), Authorize]
        public ActionResult Put(int id, UpdateTermekekDto updateTermekedDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingTermek = context.Termekek.FirstOrDefault(x => x.TermekekId == id);

                existingTermek.TermekNev = updateTermekedDto.TermekNev;
                existingTermek.Leiras = updateTermekedDto.Leiras;
                existingTermek.Menyiseg = updateTermekedDto.Menyiseg;
                existingTermek.SzinId = updateTermekedDto.SzinId;
                existingTermek.TagId = updateTermekedDto.TagId;
                existingTermek.Keputvonal = updateTermekedDto.Keputvonal;

                context.Termekek.Update(existingTermek);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}"), Authorize]
        public ActionResult Delete(int id)
        {
            using (var context = new project_databaseContext())
            {
                var existingTermek = context.Termekek.FirstOrDefault(x => x.TermekekId == id);

                context.Termekek.Remove(existingTermek);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
