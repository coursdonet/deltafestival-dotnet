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

        //log

        //lat

        public string Name { get; set; }

        public string XAxis { get; set; }

        public string YAxis { get; set; }

        public bool IsActive { get; set; }


        public bool IsObsolete { get; set; }
    }


}
