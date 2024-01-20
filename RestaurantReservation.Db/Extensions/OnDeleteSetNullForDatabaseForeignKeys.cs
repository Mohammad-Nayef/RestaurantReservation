using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

public static class OnDeleteSetNullForDatabaseForeignKeys
{
    public static void OnDeleteSetNullForForeignKeys(this ModelBuilder modelBuilder)
    {
        OnDeleteSetNullForCustomerInReservations(modelBuilder);
        OnDeleteSetNullForTableInReservations(modelBuilder);
        OnDeleteSetNullForReservationInOrders(modelBuilder);
        OnDeleteSetNullForEmployeeInOrders(modelBuilder);
        OnDeleteSetNullForOrderInOrderItems(modelBuilder);
        OnDeleteSetNullForMenuItemInOrderItems(modelBuilder);
        OnDeleteSetNullForRestaurantInMenuItems(modelBuilder);
        OnDeleteSetNullForRestaurantInEmployees(modelBuilder);
        OnDeleteSetNullForRestaurantInTables(modelBuilder);
        OnDeleteSetNullForRestaurantInReservations(modelBuilder);
    }

    private static void OnDeleteSetNullForCustomerInReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany(customer => customer.Reservations)
            .WithOne(reservation => reservation.Customer)
            .HasForeignKey(reservation => reservation.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForTableInReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>()
            .HasMany(table => table.Reservations)
            .WithOne(reservation => reservation.Table)
            .HasForeignKey(reservation => reservation.TableId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForReservationInOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasMany(reservation => reservation.Orders)
            .WithOne(order => order.Reservation)
            .HasForeignKey(order => order.ReservationId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForEmployeeInOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(employee => employee.Orders)
            .WithOne(order => order.Employee)
            .HasForeignKey(order => order.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForOrderInOrderItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(order => order.OrderItems)
            .WithOne(orderItem => orderItem.Order)
            .HasForeignKey(orderItem => orderItem.OrderId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForMenuItemInOrderItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>()
            .HasMany(menuItem => menuItem.OrderItems)
            .WithOne(orderItem => orderItem.MenuItem)
            .HasForeignKey(orderItem => orderItem.MenuItemId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForRestaurantInMenuItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .HasMany(restaurant => restaurant.MenuItems)
            .WithOne(menuItem => menuItem.Restaurant)
            .HasForeignKey(menuItem => menuItem.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForRestaurantInEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .HasMany(restaurant => restaurant.Employees)
            .WithOne(employee => employee.Restaurant)
            .HasForeignKey(employee => employee.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForRestaurantInTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .HasMany(restaurant => restaurant.Tables)
            .WithOne(table => table.Restaurant)
            .HasForeignKey(table => table.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void OnDeleteSetNullForRestaurantInReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .HasMany(restaurant => restaurant.Reservations)
            .WithOne(reservation => reservation.Restaurant)
            .HasForeignKey(reservation => reservation.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}