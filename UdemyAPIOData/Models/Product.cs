using System;

namespace UdemyAPIOData.Models
{
    public class Product
    {
        
        public int Id { get; set;}
        public string Name { get; set; }
        public int Stock { get; set;}
        public int Price { get; set;}

        public int CategoryId { get; set; }

        public DateTime? Created { get; set; }

        public virtual Category Category { get; set; }

    }
}