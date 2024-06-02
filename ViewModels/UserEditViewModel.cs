using System.ComponentModel.DataAnnotations;

namespace BashMaistoriBG.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        public int? SpecialtyId { get; set; }
    }
}
