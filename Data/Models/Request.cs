using BashMaistoriBG.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BashMaistoriBG.Data.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

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
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Status { get; set; }

        [Required]
        public string RequestorId { get; set; }

        public ApplicationUser Requestor { get; set; }
    }
}
