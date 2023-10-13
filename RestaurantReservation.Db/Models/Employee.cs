﻿namespace RestaurantReservation.Db.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public List<Order> OrderItems { get; set; } = new List<Order>();
    }
}