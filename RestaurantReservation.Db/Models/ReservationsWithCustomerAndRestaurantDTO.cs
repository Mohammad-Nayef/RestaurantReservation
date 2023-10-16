﻿namespace RestaurantReservation.Db.Models
{
    public class ReservationsWithCustomerAndRestaurantDTO
    {
        public int ReservationId { get; set; }

        public int? TableId { get; set; }

        public DateTime ReservationDate { get; set; }

        public int PartySize { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerFirstName { get; set; } = null!;

        public string CustomerLastName { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public int? RestaurantId { get; set; }

        public string RestaurantName { get; set; } = null!;

        public string RestaurantAddress { get; set; } = null!;

        public string RestaurantPhoneNumber { get; set; } = null!;

        public string RestaurantOpeningHours { get; set; } = null!;

        public override string ToString()
        {
            return $"ReservationId: {ReservationId}, TableId: {TableId}, " +
                $"ReservationDate: {ReservationDate}, PartySize: {PartySize}, " +
                $"CustomerId: {CustomerId}, CustomerFirstName: {CustomerFirstName}, " +
                $"CustomerLastName: {CustomerLastName}, CustomerEmail: {CustomerEmail}, " +
                $"CustomerPhoneNumber: {CustomerPhoneNumber}, RestaurantId: {RestaurantId}, " +
                $"RestaurantName: {RestaurantName}, RestaurantAddress: {RestaurantAddress}, " +
                $"RestaurantPhoneNumber: {RestaurantPhoneNumber}, " +
                $"RestaurantOpeningHours: {RestaurantOpeningHours}";
        }
    }
}