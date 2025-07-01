using AutoMapper;
using Web.DataTransferObject.AboutDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class AboutMapping :Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
