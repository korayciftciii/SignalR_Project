using AutoMapper;
using Web.DataTransferObject.SocialLinkDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class SocialLinkMapping : Profile
    {
        public SocialLinkMapping()
        {
            CreateMap<SocialLink, ResultSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, CreateSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, UpdateSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, GetSocialLinkByIdDto>().ReverseMap();
        }
    }
}
