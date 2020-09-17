using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}