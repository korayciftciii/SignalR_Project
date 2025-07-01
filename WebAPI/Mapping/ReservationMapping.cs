using AutoMapper;
using Web.DataTransferObject.ReservationDTO;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class ReservationMapping :Profile
    {
        public ReservationMapping()
        {
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();
        }
    }
}
