﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Photo
    {
        public int Id { get; set; }

        public string Path { get; set; }
        public int PublicationId { get; set; }
    }
}
