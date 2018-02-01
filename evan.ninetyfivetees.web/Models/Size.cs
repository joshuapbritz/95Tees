using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Models
{
    public partial class Size
    {
        public Size()
        {
            ShirtSizes = new HashSet<ShirtSizes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ShirtSizes> ShirtSizes { get; set; }
    }
}
