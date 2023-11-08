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
        public DbSet<ReservationDTO> Reservations { get; set; }
        public DbSet<ReservationsWithCustomerAndRestaurant> ReservationsWithCustomerAndRestaurant { get; set; }
        public DbSet<EmployeesWithRestaurant> EmployeesWithRestaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=RestaurantReservationCore;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.OnDeleteSetNullForForeignKeys();
            modelBuilder.SeedEntities();

            modelBuilder.Entity<ReservationsWithCustomerAndRestaurant>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vw_ReservationsWithCustomerAndRestaurant");
            });

            modelBuilder.Entity<EmployeesWithRestaurant>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vw_EmployeesWithRestaurant");
            });

            modelBuilder.HasDbFunction(typeof(RestaurantReservationDbContext)
                .GetMethod(nameof(TotalRevenueByRestaurant), new[] { typeof(int) }))
                .HasName("fn_TotalRevenue");
        }

        public int TotalRevenueByRestaurant(int restaurantId)
        {
            throw new NotSupportedException();
        }
    }
}
