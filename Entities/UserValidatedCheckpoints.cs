using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserValidatedCheckpoints

    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Checkpoint Checkpoint { get; set; }

        public int CheckpointId { get; set; }

        public DateTime TimeChecked { get; set; }

        public virtual Team Team { get; set; }

        public int TeamId { get; set; }




    }
}
