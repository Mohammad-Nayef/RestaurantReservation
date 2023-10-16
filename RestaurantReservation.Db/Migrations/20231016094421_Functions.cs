using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Functions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION fn_TotalRevenue (@restaurantId INT)
                RETURNS INT
                AS BEGIN
	                RETURN 
                        ( SELECT COALESCE(SUM(MenuItems.Price), 0) FROM Reservations AS rsrv
		                JOIN Orders
		                ON rsrv.Id = Orders.ReservationId
		                JOIN OrderItems
		                ON Orders.Id = OrderItems.OrderId
		                JOIN MenuItems
		                ON OrderItems.MenuItemId = MenuItems.Id
		                WHERE rsrv.RestaurantId = @restaurantId )
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.fn_TotalRevenue");
        }
    }
}
