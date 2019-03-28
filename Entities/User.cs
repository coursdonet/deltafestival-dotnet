using DeltaFestival.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        //  public string Email { get; set; }

        //  public string Password { get; set; }

        [Required]
        public string Pseudo { get; set; } //un utilisateur doit pouvoir choisir un pseudonyme pour le caractériser

        public virtual UserRole Role { get; set; }

        [Required]
        public int UserRoleId { get; set; } //Tous les comptes utilisateurs sont du même type + modérateurs

        [Required]
        public int MoodId { get; set; } //un utilisateur doit pouvoir choisir un état d'esprit qui permettra de regrouper les gens par affinité

        public Mood ActualMood { get; set; }

        public ICollection<Publication> Publications { get; set; }

        public string TicketCode { get; set; }//index // unique

        public bool CanPublish { get; set; }

        public int Demission { get; set; } //resign

        public bool IsActive { get; set; }

        public DateTime LastPublicationTime { get; set; }

        public List<Crush> Crushes { get; set; }

        public List<Ignored> IgnoredPeople { get; set; }

        public string Token { get; set; }

    }
}
