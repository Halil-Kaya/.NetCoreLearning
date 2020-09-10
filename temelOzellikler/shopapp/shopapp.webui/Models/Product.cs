using System.ComponentModel.DataAnnotations;

namespace temelOzellikler.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(60,MinimumLength = 10,ErrorMessage = "Ürün ismi 10-60 karakter arasında olmalı!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "fiyat girmelisiniz!")]
        [Range(1,1000)]
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        
    }
}