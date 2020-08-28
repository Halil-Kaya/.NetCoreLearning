using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
