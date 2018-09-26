using System.ComponentModel.DataAnnotations;

namespace TrainTracker.Models
{
    public class Tip
    {
        [Key]
        [MinLength(2)]
        public int TipId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        public string Comment { get; set; }
    }
}