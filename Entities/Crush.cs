using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeltaFestival.Models
{
    public class Crush
    {
        [Required]
        public int IdCurrentUser { get; set; }

        [Required]
        public int IdCrush { get; set; }
    }
}
