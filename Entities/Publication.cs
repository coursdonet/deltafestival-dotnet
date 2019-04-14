using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Publication
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Content is required."), StringLength(500, ErrorMessage = "Content cannot exceed 500 characters. ")]
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsCoupDeCoeur { get; set; }

        public User User { get; set; }
        public SuperUser SuperUser { get; set; }

        [Required]
        public string File { get; set; }

        public DateTime Date { get; set; }

        public string Hashtag { get; set; }

    }
}

