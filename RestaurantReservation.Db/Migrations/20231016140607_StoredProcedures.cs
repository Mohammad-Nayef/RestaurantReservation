using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetCustomersWithPartySizeGreaterThanValue @value INT
                AS BEGIN
	                SELECT Customers.* FROM Customers
	                JOIN Reservations
	                ON Customers.Id = Reservations.CustomerId
	                WHERE PartySize > @value
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE sp_GetCustomersWithPartySizeGreaterThanValue");
        }
    }
}
