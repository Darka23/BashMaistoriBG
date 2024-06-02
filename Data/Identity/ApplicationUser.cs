using BashMaistoriBG.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BashMaistoriBG.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }

        public string? Role { get; set; }

    }
}
