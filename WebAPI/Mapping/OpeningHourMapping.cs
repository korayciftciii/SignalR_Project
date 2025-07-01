using AutoMapper;
using Web.DataTransferObject.OpeningHourDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class OpeningHourMapping : Profile
    {
        public OpeningHourMapping()
        {
            CreateMap<OpeningHour, ResultOpeningHourDto>().ReverseMap();
            CreateMap<OpeningHour, CreateOpeningHourDto>().ReverseMap();
            CreateMap<OpeningHour, UpdateOpeningHourDto>().ReverseMap();
        }
    }
}
