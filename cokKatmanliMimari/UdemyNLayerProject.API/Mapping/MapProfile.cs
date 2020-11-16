using AutoMapper;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.API.Mapping
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
            
        }


    }
}