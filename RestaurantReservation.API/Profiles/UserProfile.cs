using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserWithoutIdDTO, User>();
            CreateMap<User, UserWithoutPasswordDTO> ();
        }
    }
}
