using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    public class SuperUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "NickName is required."), StringLength(20, ErrorMessage = "NickName value cannot exceed 20 characters. ")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Active status is required."), DefaultValue(true)]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Publish status is required."), DefaultValue(true)]
        public bool CanPublish { get; set; }
        //Nombre de demission d'equipe
        [DefaultValue(0)]
        public int Resign { get; set; }
        public int UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }
    }
}
