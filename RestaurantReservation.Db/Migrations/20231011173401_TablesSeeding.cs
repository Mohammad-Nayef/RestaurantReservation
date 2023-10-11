using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class TablesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "sample@gmail.com", "Ali", "Ahmad", "+123456789" },
                    { 2, "sample@gmail.com", "Ahmad", "Ali", "+123456789" },
                    { 3, "sample@gmail.com", "Mohammad", "Nayef", "+123456789" },
                    { 4, "sample@gmail.com", "Habeeb", "Awawdah", "+123456789" },
                    { 5, "sample@gmail.com", "Samer", "Rabai", "+123456789" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Dura", "Maxicano", "9:00 - 22:00", "+123456788" },
                    { 2, "Dura", "Julia", "9:00 - 22:00", "+123456788" },
                    { 3, "Hebron", "Al-Rayyan", "9:00 - 22:00", "+123456788" },
                    { 4, "Hebron", "Pizza Hut", "9:00 - 22:00", "+123456788" },
                    { 5, "Dura", "KFC", "9:00 - 22:00", "+123456788" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Yousef", "Iyad", "Accountant", 2 },
                    { 2, "Iyad", "Yousef", "Accountant", 1 },
                    { 3, "Owais", "Ibrahim", "Accountant", 4 },
                    { 4, "Ibrahim", "Owais", "Accountant", 5 },
                    { 5, "Mohammad", "Ahmad", "Accountant", 3 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Chicken with rice", "Maqloba", 15m, 2 },
                    { 2, "Chicken with rice", "Kabsa", 15m, 1 },
                    { 3, "Cold drink", "Iced Coffee", 10m, 1 },
                    { 4, "Cold drink", "Milk Shake Lotus", 12m, 4 },
                    { 5, "Tomato and cucumber", "Salad", 5m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 4, 2 },
                    { 3, 5, 2 },
                    { 4, 6, 3 },
                    { 5, 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4748), 1, 1 },
                    { 2, 3, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4752), 1, 2 },
                    { 3, 5, 3, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4754), 2, 2 },
                    { 4, 2, 4, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4756), 2, 1 },
                    { 5, 1, 5, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4758), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4668), 1, 2 },
                    { 2, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4704), 1, 2 },
                    { 3, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4707), 1, 2 },
                    { 4, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4709), 1, 2 },
                    { 5, 2, new DateTime(2023, 10, 11, 20, 34, 1, 242, DateTimeKind.Local).AddTicks(4712), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 3, 2, 2 },
                    { 2, 1, 2, 3 },
                    { 3, 3, 5, 5 },
                    { 4, 3, 4, 1 },
                    { 5, 3, 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
