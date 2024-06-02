using System.ComponentModel.DataAnnotations;

namespace BashMaistoriBG.Data.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
