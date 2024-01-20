﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class CustomerWithoutIdDTO
    {
        /// <summary>
        /// Only letters and spaces are allowed with length of 3 to 30 characters.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Only letters and spaces are allowed with length of 3 to 30 characters.
        /// </summary>
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
