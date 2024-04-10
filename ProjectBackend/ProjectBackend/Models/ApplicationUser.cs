using Microsoft.AspNetCore.Identity;

namespace authApi.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int EmailCode { get; set; }

    }
}
