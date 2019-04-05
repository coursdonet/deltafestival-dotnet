using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Prevention
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int Watercount { get; set; }
        public DateTime lastWaterDate { get; set; }

        public int Alcoolcount { get; set; }
        public DateTime lastAlcoolDate { get; set; }

        public string message { get; set; }
    }
}
