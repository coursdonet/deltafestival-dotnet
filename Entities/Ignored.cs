using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaFestival.Models
{
    public class Ignored
    {
        [Required]
        public int IdCurrentUser { get; set; }

        [Required]
        public int IdIgnored { get; set; }
    }
}
