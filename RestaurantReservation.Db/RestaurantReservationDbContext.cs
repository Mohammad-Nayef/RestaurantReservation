using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<MenuItemDTO> MenuItems { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<OrderItemDTO> OrderItems { get; set; }
        public DbSet<RestaurantDTO> Restaurants { get; set; }
        public DbSet<TableDTO> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=RestaurantReservationCore;");
        }
    }
}
