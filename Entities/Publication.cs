using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Publication
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Content is required."), StringLength(500, ErrorMessage = "Content cannot exceed 500 characters. ")]
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsCoupDeCoeur { get; set; }

        public SuperUser SuperUser { get; set; }



    }

}
