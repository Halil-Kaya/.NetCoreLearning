using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class Products
    {
        public Products()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
