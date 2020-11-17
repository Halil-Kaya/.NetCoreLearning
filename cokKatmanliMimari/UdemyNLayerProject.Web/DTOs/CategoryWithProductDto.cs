using System.Collections.Generic;

namespace UdemyNLayerProject.Web.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
        
    }
}