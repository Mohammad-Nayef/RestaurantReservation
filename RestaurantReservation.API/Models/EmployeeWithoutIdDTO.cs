﻿namespace RestaurantReservation.API.Models
{
    public class EmployeeWithoutIdDTO
    {
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}