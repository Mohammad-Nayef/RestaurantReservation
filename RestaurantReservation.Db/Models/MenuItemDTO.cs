﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("MenuItems")]
    public class MenuItemDTO
    {
        [Column("item_id")]
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
