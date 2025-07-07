using AutoMapper;
using Web.DataTransferObject.MoneyCaseDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class MoneyCaseMapping : Profile
    {
        public MoneyCaseMapping()
        {
            CreateMap<MoneyCase,ResultMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase,CreateMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase,UpdateMoneyCaseDto>().ReverseMap();
        }
    }
}
