using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationWithoutIdDTO, Reservation>();
            CreateMap<ReservationWithoutIdDTO, ReservationDTO>();
        }
    }
}
