using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeWithoutIdDTO, Employee>();
            CreateMap<EmployeeWithoutIdDTO, EmployeeDTO>();
        }
    }
}
