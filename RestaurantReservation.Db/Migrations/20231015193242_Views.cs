using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Views : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vw_ReservationsWithCustomerAndRestaurant AS
                SELECT 
                    rsr.Id AS ReservationId, rsr.TableId, rsr.ReservationDate, rsr.PartySize,
                    rsr.CustomerId, cust.FirstName AS CustomerFirstName, cust.LastName AS CustomerLastName,
                    cust.Email AS CustomerEmail, cust.PhoneNumber AS CustomerPhoneNumber,
                    rsr.RestaurantId, rest.Name AS RestaurantName, rest.Address AS RestaurantAddress,
                    rest.PhoneNumber AS RestaurantPhoneNumber, rest.OpeningHours AS RestaurantOpeningHours
                FROM Reservations AS rsr
                JOIN Customers AS cust
                ON rsr.CustomerId = cust.Id
                JOIN Restaurants AS rest
                ON rsr.RestaurantId = rest.Id");

            migrationBuilder.Sql(@"CREATE VIEW vw_EmployeesWithRestaurant AS
                SELECT 
	                emp.Id AS EmployeeId, emp.FirstName AS EmployeeFirstName,
	                emp.LastName AS EmployeeLastName, emp.Position AS EmployeePosition,
	                emp.RestaurantId, rest.Name AS RestaurantName, rest.Address AS RestaurantAddress,
	                rest.PhoneNumber AS RestaurantPhoneNumber, rest.OpeningHours AS RestaurantOpeningHours
                FROM Employees AS emp
                JOIN Restaurants AS rest
                ON emp.RestaurantId = rest.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vw_ReservationsWithCustomerAndRestaurant");
            migrationBuilder.Sql("DROP VIEW vw_EmployeesWithRestaurant");
        }
    }
}
