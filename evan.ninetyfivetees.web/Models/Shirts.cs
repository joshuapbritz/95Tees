using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class Shirts
    {
        public Shirts()
        {
            ShirtSizes = new HashSet<ShirtSizes>();
        }

        public int Id { get; set; }
        public int? ColorId { get; set; }
        public string Description { get; set; }
        public int? DesignId { get; set; }
        public int? GenderId { get; set; }
        public string Image { get; set; }
        public bool? Instock { get; set; }
        public int? Price { get; set; }
        public int? SeasonId { get; set; }
        public string Title { get; set; }

        public Color Color { get; set; }
        public Designs Design { get; set; }
        public Genders Gender { get; set; }
        public Shirts IdNavigation { get; set; }
        public YearSeasons Season { get; set; }
        public Shirts InverseIdNavigation { get; set; }
        public ICollection<ShirtSizes> ShirtSizes { get; set; }
    }
}
