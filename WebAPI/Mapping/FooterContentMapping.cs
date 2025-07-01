using AutoMapper;
using Web.DataTransferObject.FooterContentDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class FooterContentMapping :Profile
    {
        public FooterContentMapping()
        {
            CreateMap<FooterContent,ResultFooterContentDto>().ReverseMap();
            CreateMap<FooterContent, CreateFooterContentDto>().ReverseMap();
            CreateMap<FooterContent, UpdateFooterContentDto>().ReverseMap();
        }
    }
}
