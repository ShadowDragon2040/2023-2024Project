using Microsoft.AspNetCore.Identity;

namespace authApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public int Age { get; set; }

    }
}
