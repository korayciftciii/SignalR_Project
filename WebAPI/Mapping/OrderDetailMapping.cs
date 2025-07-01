using AutoMapper;
using Web.DataTransferObject.OrderDetailDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailByIdDto>().ReverseMap();
        }
    }
    
    
}
