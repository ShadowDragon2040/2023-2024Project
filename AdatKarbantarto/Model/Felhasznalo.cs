using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Felhasznalo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public int EmailCode { get; set; }
        public string Email { get; set; }
        public string ProfilKep { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ActivateDate { get; set; }

        public override string? ToString()
        {
            return $"Id:{Id}";
        }
    }
}
