using System;
using System.Collections.Generic;

namespace AngularTestApi.Models
{
    public partial class Categories
    {
        public Categories()
        {
            ItemCategories = new HashSet<ItemCategories>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<ItemCategories> ItemCategories { get; set; }
    }
}
