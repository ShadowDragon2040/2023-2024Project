using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.DTOs;
using ProjectBackend.Models;
using ProjectBackend.Services;
using System.Text;

namespace Webárúház_Nagy_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzamlazasController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IConfiguration _configuration;

        public SzamlazasController(IConfiguration configuration, AuthContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet, Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _context.Szamlaza.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("purchaseMail"), Authorize(Roles = "USER,ADMIN")]
        public IActionResult PurchaseMail(PurchaseDTO request)
        {
            try
            {
                var user = _context.Aspnetuser.FirstOrDefault(u => u.Id == request.UserId);
                if (user == null)
                {
                    return BadRequest("Invalid user ID!");
                }

                string[] cartItems = request.Cart.Split(';');
                StringBuilder emailBodyBuilder = new StringBuilder();
                emailBodyBuilder.Append($"Dear {user.UserName},\nThank you for your purchase.\nHere is your purchase Details:\n");

                foreach (string item in cartItems)
                {
                    string[] itemDetails = item.Trim().Split(' ');
                    if (itemDetails.Length == 3)
                    {
                        int termekId;
                        if (int.TryParse(itemDetails[0], out termekId))
                        {
                            var termek = _context.Termekek.FirstOrDefault(t => t.TermekId == termekId);
                            if (termek != null)
                            {
                                emailBodyBuilder.Append($"TermekId: {termek.TermekId}, Name: {termek.TermekNev}, Quantity: {itemDetails[1]}, Color: {itemDetails[2]}\n");
                            }

                            var szamlazas = new Szamlaza
                            {
                                UserId = request.UserId,
                                TermekId = termekId,
                                SzinHex = itemDetails[2],
                                Darab = int.Parse(itemDetails[1]),
                                VasarlasIdopontja = DateTime.Now,
                                SikeresSzalitas = false
                            };

                            _context.Szamlaza.Add(szamlazas);
                        }
                    }
                }
                emailBodyBuilder.Append("\nRegards,\nPrintFusion");
                _context.SaveChanges();

                EmailService.SendMail(request.UserEmail, "Purchase Details", emailBodyBuilder.ToString(), _configuration);

                return Ok("Purchase details stored successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing purchase details: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }


        //userId alapján
        [HttpGet("{id}"), Authorize(Roles = "USER,ADMIN")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var result = await _context.Szamlaza.Where(x => x.UserId == id).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Post(CreatedSzamlazasokDto createdSzamlazasokDto)
        {
            try
            {
                var request = new Szamlaza
                {
                    UserId = createdSzamlazasokDto.UserId,
                    TermekId = createdSzamlazasokDto.TermekId,
                    SzinHex = createdSzamlazasokDto.SzinHex,
                    Darab = createdSzamlazasokDto.Darab,
                    VasarlasIdopontja = DateTime.Now,
                    SikeresSzalitas = false
                };

                _context.Szamlaza.Add(request);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Put(int Id, UpdateSzamlazasokDto updateSzamlazasokDto)
        {
            try
            {
                var existingSzamlazas = _context.Szamlaza.FirstOrDefault(x => x.SzamlazasId == Id);
               
                existingSzamlazas.UserId = updateSzamlazasokDto.UserId;
                existingSzamlazas.TermekId = updateSzamlazasokDto.TermekId;
                existingSzamlazas.VasarlasIdopontja = DateTime.Now;
                existingSzamlazas.SikeresSzalitas = updateSzamlazasokDto.SikeresSzalitas;
                existingSzamlazas.SzinHex = updateSzamlazasokDto.SzinHex;

                _context.Szamlaza.Update(existingSzamlazas);
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
                var existingSzamlazas = _context.Szamlaza.FirstOrDefault(x => x.SzamlazasId == id);

                _context.Szamlaza.Remove(existingSzamlazas);
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
