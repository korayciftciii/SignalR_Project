using AutoMapper;
using Web.DataTransferObject.FoodDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class FoodMapping :Profile
    {
        public FoodMapping()
        {
            CreateMap<Food, ResultFoodDto>().ReverseMap();
            CreateMap<Food, CreateFoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();
            CreateMap<Food,GetFoodByIdDto>().ReverseMap();
        }
    }
}
