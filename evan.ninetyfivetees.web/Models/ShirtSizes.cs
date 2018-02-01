using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class ShirtSizes
    {
        public int ShirtId { get; set; }
        public int SizeId { get; set; }

        public Shirts Shirt { get; set; }
        public Size Size { get; set; }
    }
}
