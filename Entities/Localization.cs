using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Localization
    {

        public Guid Id { get; set; }

        //todo 
        //log
        public double Longitude { get; set; }
        //lat
        public double Latitude { get; set; }
        //date
        public DateTime EmitTime { get; set; }

        public int UserId { get; set; }

        public int UserTeamId { get; set; }

        public int ZoneId { get; set; }




    }
}
