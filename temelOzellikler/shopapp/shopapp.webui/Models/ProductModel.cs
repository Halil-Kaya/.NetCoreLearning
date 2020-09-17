using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "name zorunlu bir alan")]
        [StringLength(60,MinimumLength = 2,ErrorMessage = "ürün ismi 2 ile 10 arasında olmalı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url zorunlu bir alan")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Price zorunlu bir alan")]
        [Range(1,10000,ErrorMessage = "Price 1 ile 10000 arasında olmalı")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Description zorunlu bir alan")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ImageUrl zorunlu bir alan")]
        public string ImageUrl { get; set; }
        public bool IsApproves { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}