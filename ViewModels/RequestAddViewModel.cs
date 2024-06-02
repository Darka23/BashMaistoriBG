using BashMaistoriBG.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BashMaistoriBG.ViewModels
{
    public class RequestAddViewModel
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public int SpecialtyId { get; set; }

        [Required]
        public Specialty Specialty { get; set; }

        [Required]
        public decimal Budget { get; set; }
    }
}
