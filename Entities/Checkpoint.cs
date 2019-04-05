using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Checkpoint
    {
        public int Id { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public string Name { get; set; }

        public DateTime LastDisabled { get; set; }

        public bool IsObsolete { get; set; }

        public bool IsActive { get; set; }

        public int AreaOfAction { get; set; }

        public Checkpoint ()
        {
            AreaOfAction = 10;
        }
    }


}
