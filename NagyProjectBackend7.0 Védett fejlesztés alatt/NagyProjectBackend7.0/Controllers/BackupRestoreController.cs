using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using NagyProjectBackend7._0.Models;

namespace NagyProjectBackend7._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BackupRestoreController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public BackupRestoreController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("Backup/{fileName}")]
        [HttpPost]
        public async Task<IActionResult> SQLBackup(string fileName)
        {
            string errorMessage = "";
            var context = new ProjectDatabaseContext();
            try
            {
                string sqlDataSource = context.Database.GetConnectionString();
                MySqlCommand command = new MySqlCommand();
                MySqlBackup backup= new MySqlBackup(command);
                using (MySqlConnection connection=new MySqlConnection(sqlDataSource))
                {
                    command.Connection = connection;
                    connection.Open();
                    var filePath = "SQLBackupRestore/" + fileName;
                    backup.ExportToFile(filePath);
                    connection.Close();
                    if (System.IO.File.Exists(filePath))
                    {
                        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
                        return File(bytes,"text/plain",Path.GetFileName(filePath));
                    }
                    else
                    {
                        errorMessage = "There is no such file!";
                        byte[] message=new byte[errorMessage.Length];
                        for (int i = 0; i < errorMessage.Length; i++)
                        {
                            message[i] = Convert.ToByte(errorMessage[i]);
                        }
                        return File(message, "text/plain","Error.txt");
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
