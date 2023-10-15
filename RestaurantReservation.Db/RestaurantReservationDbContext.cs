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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=RestaurantReservationCore;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnDeleteSetNullForForeignKeys(modelBuilder);

            CustomersSeeding(modelBuilder);
            EmployeesSeeding(modelBuilder);
            MenuItemsSeeding(modelBuilder);
            OrdersSeeding(modelBuilder);
            OrderItemsSeeding(modelBuilder);
            ReservationsSeeding(modelBuilder);
            RestaurantsSeeding(modelBuilder);
            TablesSeeding(modelBuilder);
        }

        private static void OnDeleteSetNullForForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDTO>()
                .HasMany(customer => customer.Reservations)
                .WithOne(reservation => reservation.Customer)
                .HasForeignKey(reservation => reservation.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TableDTO>()
                .HasMany(a => a.Reservations)
                .WithOne(reservation => reservation.Table)
                .HasForeignKey(reservation => reservation.TableId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ReservationDTO>()
                .HasMany(reservation => reservation.Orders)
                .WithOne(a => a.Reservation)
                .HasForeignKey(a => a.ReservationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RestaurantDTO>()
                .HasMany(restaurant => restaurant.Reservations)
                .WithOne(reservation => reservation.Restaurant)
                .HasForeignKey(reservation => reservation.RestaurantId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RestaurantDTO>()
                .HasMany(restaurant => restaurant.Tables)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RestaurantDTO>()
                .HasMany(restaurant => restaurant.Employees)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RestaurantDTO>()
                .HasMany(restaurant => restaurant.MenuItems)
                .WithOne(a => a.Restaurant)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<MenuItemDTO>()
                .HasMany(a => a.OrderItems)
                .WithOne(a => a.MenuItem)
                .HasForeignKey(a => a.MenuItemId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderDTO>()
                .HasMany(a => a.OrderItems)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeeDTO>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private static void TablesSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableDTO>().HasData(
                            new TableDTO { Id = 1, RestaurantId = 1, Capacity = 3 },
                            new TableDTO { Id = 2, RestaurantId = 2, Capacity = 4 },
                            new TableDTO { Id = 3, RestaurantId = 2, Capacity = 5 },
                            new TableDTO { Id = 4, RestaurantId = 3, Capacity = 6 },
                            new TableDTO { Id = 5, RestaurantId = 1, Capacity = 7 });
        }

        private static void RestaurantsSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantDTO>().HasData(
                            new RestaurantDTO { Id = 1, Name = "Maxicano", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                            new RestaurantDTO { Id = 2, Name = "Julia", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                            new RestaurantDTO { Id = 3, Name = "Al-Rayyan", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                            new RestaurantDTO { Id = 4, Name = "Pizza Hut", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                            new RestaurantDTO { Id = 5, Name = "KFC", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" });
        }

        private static void ReservationsSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationDTO>().HasData(
                            new ReservationDTO { Id = 1, CustomerId = 2, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 1 },
                            new ReservationDTO { Id = 2, CustomerId = 3, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 2 },
                            new ReservationDTO { Id = 3, CustomerId = 5, RestaurantId = 2, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 3 },
                            new ReservationDTO { Id = 4, CustomerId = 2, RestaurantId = 2, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 4 },
                            new ReservationDTO { Id = 5, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 5 });
        }

        private static void OrderItemsSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDTO>().HasData(
                            new OrderItemDTO { Id = 1, OrderId = 2, MenuItemId = 3, Quantity = 2 },
                            new OrderItemDTO { Id = 2, OrderId = 2, MenuItemId = 1, Quantity = 3 },
                            new OrderItemDTO { Id = 3, OrderId = 5, MenuItemId = 3, Quantity = 5 },
                            new OrderItemDTO { Id = 4, OrderId = 4, MenuItemId = 3, Quantity = 1 },
                            new OrderItemDTO { Id = 5, OrderId = 3, MenuItemId = 3, Quantity = 2 });
        }

        private static void OrdersSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDTO>().HasData(
                            new OrderDTO { Id = 1, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                            new OrderDTO { Id = 2, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                            new OrderDTO { Id = 3, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                            new OrderDTO { Id = 4, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                            new OrderDTO { Id = 5, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 });
        }

        private static void MenuItemsSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemDTO>().HasData(
                            new MenuItemDTO { Id = 1, RestaurantId = 2, Name = "Maqloba", Description = "Chicken with rice", Price = 15 },
                            new MenuItemDTO { Id = 2, RestaurantId = 1, Name = "Kabsa", Description = "Chicken with rice", Price = 15 },
                            new MenuItemDTO { Id = 3, RestaurantId = 1, Name = "Iced Coffee", Description = "Cold drink", Price = 10 },
                            new MenuItemDTO { Id = 4, RestaurantId = 4, Name = "Milk Shake Lotus", Description = "Cold drink", Price = 12 },
                            new MenuItemDTO { Id = 5, RestaurantId = 3, Name = "Salad", Description = "Tomato and cucumber", Price = 5 });
        }

        private static void EmployeesSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDTO>().HasData(
                new EmployeeDTO { Id = 1, RestaurantId = 2, FirstName = "Yousef", LastName = "Iyad", Position = "Accountant" },
                new EmployeeDTO { Id = 2, RestaurantId = 1, FirstName = "Iyad", LastName = "Yousef", Position = "Accountant" },
                new EmployeeDTO { Id = 3, RestaurantId = 4, FirstName = "Owais", LastName = "Ibrahim", Position = "Accountant" },
                new EmployeeDTO { Id = 4, RestaurantId = 5, FirstName = "Ibrahim", LastName = "Owais", Position = "Accountant" },
                new EmployeeDTO { Id = 5, RestaurantId = 3, FirstName = "Mohammad", LastName = "Ahmad", Position = "Accountant" });
        }

        private static void CustomersSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDTO>().HasData(
                new CustomerDTO { Id = 1, FirstName = "Ali", LastName = "Ahmad", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
                new CustomerDTO { Id = 2, FirstName = "Ahmad", LastName = "Ali", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
                new CustomerDTO { Id = 3, FirstName = "Mohammad", LastName = "Nayef", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
                new CustomerDTO { Id = 4, FirstName = "Habeeb", LastName = "Awawdah", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
                new CustomerDTO { Id = 5, FirstName = "Samer", LastName = "Rabai", Email = "sample@gmail.com", PhoneNumber = "+123456789" });
        }
    }
}
