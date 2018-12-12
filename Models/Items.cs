using System;
using System.Collections.Generic;

namespace AngularTestApi.Models
{
    public partial class Items
    {
        public Items()
        {
            ItemCategories = new HashSet<ItemCategories>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }

        public ICollection<ItemCategories> ItemCategories { get; set; }
    }
}
