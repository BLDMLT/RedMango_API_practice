using Microsoft.AspNetCore.Identity;

namespace RedMango_API_practice.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name {get; set;}
    }
}
