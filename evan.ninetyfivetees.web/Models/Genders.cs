using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class Genders
    {
        public Genders()
        {
            Shirts = new HashSet<Shirts>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Shirts> Shirts { get; set; }
    }
}
