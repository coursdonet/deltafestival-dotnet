using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaFestival.Models
{
    public class Ignored
    {
        public int Id { get; set; }
        [Required]
        public int IdCurrentUser { get; set; }

        [Required]
        public int IdIgnored { get; set; }
    }
}
