using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
