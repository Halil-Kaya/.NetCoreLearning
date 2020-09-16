using System;
using System.Collections.Generic;

namespace test2.Data.EfCore
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
