using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    restaurant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opening_hours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.restaurant_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurants_RestaurantDTOId",
                        column: x => x.RestaurantDTOId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id");
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RestaurantDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantDTOId",
                        column: x => x.RestaurantDTOId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    table_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    RestaurantDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.table_id);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_RestaurantDTOId",
                        column: x => x.RestaurantDTOId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    restaurant_id = table.Column<int>(type: "int", nullable: false),
                    table_id = table.Column<int>(type: "int", nullable: false),
                    reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    party_size = table.Column<int>(type: "int", nullable: false),
                    CustomerDTOId = table.Column<int>(type: "int", nullable: true),
                    RestaurantDTOId = table.Column<int>(type: "int", nullable: true),
                    TableDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerDTOId",
                        column: x => x.CustomerDTOId,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantDTOId",
                        column: x => x.RestaurantDTOId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurant_id");
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableDTOId",
                        column: x => x.TableDTOId,
                        principalTable: "Tables",
                        principalColumn: "table_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_amount = table.Column<int>(type: "int", nullable: false),
                    EmployeeDTOId = table.Column<int>(type: "int", nullable: true),
                    ReservationDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeDTOId",
                        column: x => x.EmployeeDTOId,
                        principalTable: "Employees",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_Orders_Reservations_ReservationDTOId",
                        column: x => x.ReservationDTOId,
                        principalTable: "Reservations",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    MenuItemDTOId = table.Column<int>(type: "int", nullable: true),
                    OrderDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemDTOId",
                        column: x => x.MenuItemDTOId,
                        principalTable: "MenuItems",
                        principalColumn: "item_id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderDTOId",
                        column: x => x.OrderDTOId,
                        principalTable: "Orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantDTOId",
                table: "Employees",
                column: "RestaurantDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantDTOId",
                table: "MenuItems",
                column: "RestaurantDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemDTOId",
                table: "OrderItems",
                column: "MenuItemDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderDTOId",
                table: "OrderItems",
                column: "OrderDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeDTOId",
                table: "Orders",
                column: "EmployeeDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReservationDTOId",
                table: "Orders",
                column: "ReservationDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerDTOId",
                table: "Reservations",
                column: "CustomerDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantDTOId",
                table: "Reservations",
                column: "RestaurantDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableDTOId",
                table: "Reservations",
                column: "TableDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantDTOId",
                table: "Tables",
                column: "RestaurantDTOId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
