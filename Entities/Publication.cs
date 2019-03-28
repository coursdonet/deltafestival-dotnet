using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Publication
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public string Content { get; set; } //attention : seulement pour les modérateurs 

        public bool IsCoupDeCoeur { get; set; }

        public User User { get; set; }

        [Required]
        public string File { get; set; }

        public DateTime Date { get; set; }

        public string Hashtag { get; set; }

    }
}
