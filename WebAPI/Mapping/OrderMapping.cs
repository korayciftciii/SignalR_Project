using AutoMapper;
using Web.DataTransferObject.OrderDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderByIdDto>().ReverseMap();
        }
    }
}
