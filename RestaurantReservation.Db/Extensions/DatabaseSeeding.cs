using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

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
        SeedUsers(modelBuilder);
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                        new User { Id = 1, FirstName = "Mohammad", LastName = "Nayef", Username = "moha", Password = "21321321321321" },
                        new User { Id = 2, FirstName = "Mohammad", LastName = "Ali", Username = "moha2", Password = "21321321321321" },
                        new User { Id = 3, FirstName = "Ayman", LastName = "Ahmad", Username = "ayman", Password = "21321321321321" },
                        new User { Id = 4, FirstName = "Omar", LastName = "Qusai", Username = "omar", Password = "21321321321321" },
                        new User { Id = 5, FirstName = "Mohammad", LastName = "Fareed", Username = "moha3", Password = "21321321321321" });
    }

    private static void SeedTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>().HasData(
                        new Table { Id = 1, RestaurantId = 1, Capacity = 3 },
                        new Table { Id = 2, RestaurantId = 2, Capacity = 4 },
                        new Table { Id = 3, RestaurantId = 2, Capacity = 5 },
                        new Table { Id = 4, RestaurantId = 3, Capacity = 6 },
                        new Table { Id = 5, RestaurantId = 1, Capacity = 7 });
    }

    private static void SeedRestaurants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasData(
                        new Restaurant { Id = 1, Name = "Maxicano", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new Restaurant { Id = 2, Name = "Julia", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new Restaurant { Id = 3, Name = "Al-Rayyan", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new Restaurant { Id = 4, Name = "Pizza Hut", Address = "Hebron", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" },
                        new Restaurant { Id = 5, Name = "KFC", Address = "Dura", PhoneNumber = "+123456788", OpeningHours = "9:00 - 22:00" });
    }

    private static void SeedReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>().HasData(
                        new Reservation { Id = 1, CustomerId = 2, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 1 },
                        new Reservation { Id = 2, CustomerId = 3, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 2 },
                        new Reservation { Id = 3, CustomerId = 5, RestaurantId = 2, TableId = 2, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 3 },
                        new Reservation { Id = 4, CustomerId = 2, RestaurantId = 2, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 4 },
                        new Reservation { Id = 5, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("1-1-2000"), PartySize = 5 });
    }

    private static void SeedOrderItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>().HasData(
                        new OrderItem { Id = 1, OrderId = 2, MenuItemId = 3, Quantity = 2 },
                        new OrderItem { Id = 2, OrderId = 2, MenuItemId = 1, Quantity = 3 },
                        new OrderItem { Id = 3, OrderId = 5, MenuItemId = 3, Quantity = 5 },
                        new OrderItem { Id = 4, OrderId = 4, MenuItemId = 3, Quantity = 1 },
                        new OrderItem { Id = 5, OrderId = 3, MenuItemId = 3, Quantity = 2 });
    }

    private static void SeedOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(
                        new Order { Id = 1, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 2 },
                        new Order { Id = 2, ReservationId = 1, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 3 },
                        new Order { Id = 3, ReservationId = 3, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 7 },
                        new Order { Id = 4, ReservationId = 3, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 1 },
                        new Order { Id = 5, ReservationId = 4, EmployeeId = 2, OrderDate = DateTime.Parse("1-1-2000"), TotalAmount = 1 });
    }

    private static void SeedMenuItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>().HasData(
                        new MenuItem { Id = 1, RestaurantId = 2, Name = "Maqloba", Description = "Chicken with rice", Price = 15 },
                        new MenuItem { Id = 2, RestaurantId = 1, Name = "Kabsa", Description = "Chicken with rice", Price = 15 },
                        new MenuItem { Id = 3, RestaurantId = 1, Name = "Iced Coffee", Description = "Cold drink", Price = 10 },
                        new MenuItem { Id = 4, RestaurantId = 4, Name = "Milk Shake Lotus", Description = "Cold drink", Price = 12 },
                        new MenuItem { Id = 5, RestaurantId = 3, Name = "Salad", Description = "Tomato and cucumber", Price = 5 });
    }

    private static void SeedEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, RestaurantId = 2, FirstName = "Yousef", LastName = "Iyad", Position = EmployeePositions.Accountant },
            new Employee { Id = 2, RestaurantId = 1, FirstName = "Iyad", LastName = "Yousef", Position = EmployeePositions.Accountant },
            new Employee { Id = 3, RestaurantId = 4, FirstName = "Owais", LastName = "Ibrahim", Position = EmployeePositions.Manager },
            new Employee { Id = 4, RestaurantId = 5, FirstName = "Ibrahim", LastName = "Owais", Position = EmployeePositions.Accountant },
            new Employee { Id = 5, RestaurantId = 3, FirstName = "Mohammad", LastName = "Ahmad", Position = EmployeePositions.Manager });
    }

    private static void SeedCustomers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FirstName = "Ali", LastName = "Ahmad", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new Customer { Id = 2, FirstName = "Ahmad", LastName = "Ali", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new Customer { Id = 3, FirstName = "Mohammad", LastName = "Nayef", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new Customer { Id = 4, FirstName = "Habeeb", LastName = "Awawdah", Email = "sample@gmail.com", PhoneNumber = "+123456789" },
            new Customer { Id = 5, FirstName = "Samer", LastName = "Rabai", Email = "sample@gmail.com", PhoneNumber = "+123456789" });
    }

}