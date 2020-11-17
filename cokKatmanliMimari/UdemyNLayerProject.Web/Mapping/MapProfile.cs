using AutoMapper;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.Mapping
{
    public class MapProfile : Profile
    {
        
        public MapProfile(){
            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();

            CreateMap<Category,CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto,Category>();
            
            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto,Product>();

            CreateMap<Product,ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto,Product>();
            
        }


    }
}