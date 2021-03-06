using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class UserConcerts
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Concert Concert { get; set; }
        public int ConcertId { get; set; }
    }

}
