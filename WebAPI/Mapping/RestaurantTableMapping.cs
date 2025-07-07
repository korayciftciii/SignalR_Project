using AutoMapper;
using Web.DataTransferObject.RestaurantTableDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class RestaurantTableMapping : Profile
    {
        public RestaurantTableMapping()
        {

            CreateMap<RestaurantTable, ResultRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, CreateRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, UpdateRestaurantTableDto>().ReverseMap();
        }
    }
}
