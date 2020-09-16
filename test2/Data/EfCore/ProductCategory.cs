using System;
using System.Collections.Generic;

namespace test2.Data.EfCore
{
    public partial class ProductCategory
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Products Product { get; set; }
    }
}
