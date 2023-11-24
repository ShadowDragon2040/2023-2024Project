using Microsoft.AspNetCore.Mvc;
using Webárúház_Nagy_Project.DTOs;
using Webárúház_Nagy_Project.Models;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new project_databaseContext())
            {
                return Ok(context.Termekek.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            using (var context = new project_databaseContext())
            {
                var result = context.Termekek.Where(x => x.Id == id);
                return Ok(result);
            }
        }

        [HttpPost]
        public ActionResult<TermekekDto> Post(CreatedTermekekDto createdTermekekDto)
        {
            using (var context = new project_databaseContext())
            {
                var request = new Termekek
                {
                    Id = Guid.NewGuid(),
                    TermekNev = createdTermekekDto.TermekNev,
                    Leiras = createdTermekekDto.Leiras,
                    Menyiseg = createdTermekekDto.Menyiseg,
                    Szin = createdTermekekDto.Szin,
                    Tag = createdTermekekDto.Tag,
                    Keputvonal = createdTermekekDto.Keputvonal,
                };

                context.Termekek.Add(request);
                context.SaveChanges();

                return Ok(/*request.AsDto()*/);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateTermekekDto updateTermekedDto)
        {
            using (var context = new project_databaseContext())
            {
                var existingTermek = context.Termekek.FirstOrDefault(x => x.Id == id);

                existingTermek.TermekNev = updateTermekedDto.TermekNev;
                existingTermek.Leiras = updateTermekedDto.Leiras;
                existingTermek.Menyiseg = updateTermekedDto.Menyiseg;
                existingTermek.Szin = updateTermekedDto.Szin;
                existingTermek.Tag = updateTermekedDto.Tag;
                existingTermek.Keputvonal = updateTermekedDto.Keputvonal;

                context.Termekek.Update(existingTermek);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            using (var context = new project_databaseContext())
            {
                var existingTermek = context.Termekek.FirstOrDefault(x => x.Id == id);

                context.Termekek.Remove(existingTermek);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
