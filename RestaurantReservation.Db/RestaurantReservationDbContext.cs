using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationsWithCustomerAndRestaurant> ReservationsWithCustomerAndRestaurant { get; set; }
        public DbSet<EmployeesWithRestaurant> EmployeesWithRestaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=RestaurantReservationCore;")
                .LogTo(Console.WriteLine, LogLevel.Information);
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
