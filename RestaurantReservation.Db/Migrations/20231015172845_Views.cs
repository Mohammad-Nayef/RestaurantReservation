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
            migrationBuilder.Sql(
                @"CREATE VIEW vw_ReservationsWithCustomerAndRestaurant AS
                    SELECT 
                        rsr.Id AS ReservationID, rsr.TableId, rsr.ReservationDate, rsr.PartySize,
                        rsr.CustomerId, cust.FirstName AS CustomerFirstName, cust.LastName AS CustomerLastName,
                        cust.Email AS CustomerEmail, cust.PhoneNumber AS CustomerPhoneNumber,
                        rsr.RestaurantId, rest.Name AS RestaurantName, rest.Address AS RestaurantAddress,
                        rest.PhoneNumber AS RestaurantPhoneNumber, rest.OpeningHours AS RestaurantOpeningHours
                    FROM Reservations AS rsr
                    JOIN Customers AS cust
                    ON rsr.CustomerId = cust.Id
                    JOIN Restaurants AS rest
                    ON rsr.RestaurantId = rest.Id"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vw_ReservationsWithCustomerAndRestaurant");
        }
    }
}
