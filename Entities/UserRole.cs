using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Libelle is required.")]
        public string Libelle { get; set; }
        //public vICollection<SuperUser> SuperUsers { get; set; }
    }
}
