using Microsoft.AspNetCore.Identity;

namespace eBusinessWebApp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
