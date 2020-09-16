using System;
using System.Collections.Generic;

namespace test2.Data.EfCore
{
    public partial class Products
    {
        public Products()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
