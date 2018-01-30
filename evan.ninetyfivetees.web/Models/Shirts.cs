using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class Shirts
    {
        public int Id { get; set; }
        public int? DesignId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }

        public Color Color { get; set; }
        public Designs Design { get; set; }
        public Size Size { get; set; }
    }
}
