using System;
using System.Collections.Generic;

namespace AngularTestApi.Models
{
    public partial class ItemCategories
    {
        public int ItemCategoryId { get; set; }
        public int? ItemId { get; set; }
        public int? CategoryId { get; set; }

        public Categories Category { get; set; }
        public Items Item { get; set; }
    }
}
