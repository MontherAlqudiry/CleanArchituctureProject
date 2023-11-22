using Microsoft.AspNetCore.Identity;

namespace Application.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Fullname { get; set; }
        public string? Address { get; set; }

    }
}
