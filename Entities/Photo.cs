using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Photo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Path is required.")]
        public string Path { get; set; }

        public int PublicationId { get; set; }
        [ForeignKey("PublicationId")]
        public Publication Publication { get; set; }

    }
}
