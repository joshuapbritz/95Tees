﻿using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class Designs
    {
        public Designs()
        {
            Shirts = new HashSet<Shirts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Shirts> Shirts { get; set; }
    }
}
