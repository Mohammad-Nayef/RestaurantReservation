using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

public static class DatabaseSeeding
{
    public static void SeedEntities(this ModelBuilder modelBuilder)
    {
        SeedCustomers(modelBuilder);
        SeedEmployees(modelBuilder);
        SeedMenuItems(modelBuilder);
        SeedOrders(modelBuilder);
        SeedOrderItems(modelBuilder);
        SeedReservations(modelBuilder);
        SeedRestaurants(modelBuilder);
        SeedTables(modelBuilder);
    }

    private static void SeedTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableDTO>().HasData(
                        new TableDTO { Id = 1, RestaurantId = 1, Capacity = 3 },
                        new TableDTO { Id = 2, RestaurantId = 2, Capacity = 4 },
                        new TableDTO { Id = 3, RestaurantId = 2, Capacity = 5 },
                        new TableDTO { Id = 4, RestaurantId = 3, Capacity = 6 },
                        new TableDTO { Id = 5, RestaurantId = 1, Capacity = 7 });
    }

    private static void SeedRestaurants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RestaurantDTO>().HasData(
                        new RestaurantDTO { Id = 1, Name = "Maxicano", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new RestaurantDTO { Id = 2, Name = "Julia", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new RestaurantDTO { Id = 3, Name = "Al-Rayyan", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new RestaurantDTO { Id = 4, Name = "Pizza Hut", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new RestaurantDTO { Id = 5, Name = "KFC", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" });
    }

    private static void SeedReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationDTO>().HasData(
                        new ReservationDTO { Id = 1, CustomerId = 2, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 1 },
                        new ReservationDTO { Id = 2, CustomerId = 3, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 2 },
                        new ReservationDTO { Id = 3, CustomerId = 5, RestaurantId = 2, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 3 },
                        new ReservationDTO { Id = 4, CustomerId = 2, RestaurantId = 2, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 4 },
                        new ReservationDTO { Id = 5, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 5 });
    }

    private static void SeedOrderItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItemDTO>().HasData(
                        new OrderItemDTO { Id = 1, OrderId = 2, MenuItemId = 3, Quantity = 2 },
                        new OrderItemDTO { Id = 2, OrderId = 2, MenuItemId = 1, Quantity = 3 },
                        new OrderItemDTO { Id = 3, OrderId = 5, MenuItemId = 3, Quantity = 5 },
                        new OrderItemDTO { Id = 4, OrderId = 4, MenuItemId = 3, Quantity = 1 },
                        new OrderItemDTO { Id = 5, OrderId = 3, MenuItemId = 3, Quantity = 2 });
    }

    private static void SeedOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDTO>().HasData(
                        new OrderDTO { Id = 1, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                        new OrderDTO { Id = 2, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 3 },
                        new OrderDTO { Id = 3, ReservationId = 3, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 7 },
                        new OrderDTO { Id = 4, ReservationId = 3, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 1 },
                        new OrderDTO { Id = 5, ReservationId = 4, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 1 });
    }

    private static void SeedMenuItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItemDTO>().HasData(
                        new MenuItemDTO { Id = 1, RestaurantId = 2, Name = "Maqloba", Description = "Chicken with rice", Price = 15 },
                        new MenuItemDTO { Id = 2, RestaurantId = 1, Name = "Kabsa", Description = "Chicken with rice", Price = 15 },
                        new MenuItemDTO { Id = 3, RestaurantId = 1, Name = "Iced Coffee", Description = "Cold drink", Price = 10 },
                        new MenuItemDTO { Id = 4, RestaurantId = 4, Name = "Milk Shake Lotus", Description = "Cold drink", Price = 12 },
                        new MenuItemDTO { Id = 5, RestaurantId = 3, Name = "Salad", Description = "Tomato and cucumber", Price = 5 });
    }

    private static void SeedEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDTO>().HasData(
            new EmployeeDTO { Id = 1, RestaurantId = 2, FirstName = "Yousef", LastName = "Iyad", Position = EmployeePositions.Accountant },
            new EmployeeDTO { Id = 2, RestaurantId = 1, FirstName = "Iyad", LastName = "Yousef", Position = EmployeePositions.Accountant },
            new EmployeeDTO { Id = 3, RestaurantId = 4, FirstName = "Owais", LastName = "Ibrahim", Position = EmployeePositions.Manager },
            new EmployeeDTO { Id = 4, RestaurantId = 5, FirstName = "Ibrahim", LastName = "Owais", Position = EmployeePositions.Accountant },
            new EmployeeDTO { Id = 5, RestaurantId = 3, FirstName = "Mohammad", LastName = "Ahmad", Position = EmployeePositions.Manager });
    }

    private static void SeedCustomers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDTO>().HasData(
            new CustomerDTO { Id = 1, FirstName = "Ali", LastName = "Ahmad", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new CustomerDTO { Id = 2, FirstName = "Ahmad", LastName = "Ali", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new CustomerDTO { Id = 3, FirstName = "Mohammad", LastName = "Nayef", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new CustomerDTO { Id = 4, FirstName = "Habeeb", LastName = "Awawdah", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new CustomerDTO { Id = 5, FirstName = "Samer", LastName = "Rabai", Email = "sample@gmail.com", PhoneNumber = "+123456789" });
    }

}