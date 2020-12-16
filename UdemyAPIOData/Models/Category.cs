using System.Collections.Generic;

namespace UdemyAPIOData.Models
{
    public class Category
    {
        
        public int Id {get; set;}
        public string Name { get; set;}

        public ICollection<Product> Products { get; set; }

    }
}