using Microsoft.AspNetCore.Identity;

namespace ElectDisciplines_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
