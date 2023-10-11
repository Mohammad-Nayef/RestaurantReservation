﻿namespace RestaurantReservation.Db.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? RestaurantId { get; set; }

        public int? TableId { get; set; }

        public DateTime ReservationDate { get; set; }

        public int PartySize { get; set; }

        public List<Order> Reservations { get; set; } = new List<Order>();
    }
}
