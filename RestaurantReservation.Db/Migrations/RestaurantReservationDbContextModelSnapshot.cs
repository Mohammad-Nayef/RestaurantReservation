﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Models.CustomerDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "sample@gmail.com",
                            FirstName = "Ali",
                            LastName = "Ahmad",
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Id = 2,
                            Email = "sample@gmail.com",
                            FirstName = "Ahmad",
                            LastName = "Ali",
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Id = 3,
                            Email = "sample@gmail.com",
                            FirstName = "Mohammad",
                            LastName = "Nayef",
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Id = 4,
                            Email = "sample@gmail.com",
                            FirstName = "Habeeb",
                            LastName = "Awawdah",
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Id = 5,
                            Email = "sample@gmail.com",
                            FirstName = "Samer",
                            LastName = "Rabai",
                            PhoneNumber = "+123456789"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.EmployeeDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Yousef",
                            LastName = "Iyad",
                            Position = "Accountant",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Iyad",
                            LastName = "Yousef",
                            Position = "Accountant",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Owais",
                            LastName = "Ibrahim",
                            Position = "Accountant",
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Ibrahim",
                            LastName = "Owais",
                            Position = "Accountant",
                            RestaurantId = 5
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Mohammad",
                            LastName = "Ahmad",
                            Position = "Accountant",
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chicken with rice",
                            Name = "Maqloba",
                            Price = 15m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Chicken with rice",
                            Name = "Kabsa",
                            Price = 15m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Cold drink",
                            Name = "Iced Coffee",
                            Price = 10m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cold drink",
                            Name = "Milk Shake Lotus",
                            Price = 12m,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Tomato and cucumber",
                            Name = "Salad",
                            Price = 5m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 2
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 2
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 2
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 2
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 3,
                            OrderId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 1,
                            OrderId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 3,
                            OrderId = 5,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 3,
                            OrderId = 4,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuItemId = 3,
                            OrderId = 3,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.ReservationDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            PartySize = 1,
                            ReservationDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 3,
                            PartySize = 2,
                            ReservationDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 5,
                            PartySize = 3,
                            ReservationDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2,
                            PartySize = 4,
                            ReservationDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 2,
                            TableId = 1
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 1,
                            PartySize = 5,
                            ReservationDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 1,
                            TableId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.RestaurantDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Dura",
                            Name = "Maxicano",
                            OpeningHours = "9:00 - 22:00",
                            PhoneNumber = "+123456788"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Dura",
                            Name = "Julia",
                            OpeningHours = "9:00 - 22:00",
                            PhoneNumber = "+123456788"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Hebron",
                            Name = "Al-Rayyan",
                            OpeningHours = "9:00 - 22:00",
                            PhoneNumber = "+123456788"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Hebron",
                            Name = "Pizza Hut",
                            OpeningHours = "9:00 - 22:00",
                            PhoneNumber = "+123456788"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Dura",
                            Name = "KFC",
                            OpeningHours = "9:00 - 22:00",
                            PhoneNumber = "+123456788"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.TableDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 3,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 4,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 5,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 6,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 7,
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.EmployeeDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.RestaurantDTO", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItemDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.RestaurantDTO", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.EmployeeDTO", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.Db.Models.ReservationDTO", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItemDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.MenuItemDTO", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.Db.Models.OrderDTO", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.ReservationDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.CustomerDTO", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.Db.Models.RestaurantDTO", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.Db.Models.TableDTO", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.TableDTO", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.RestaurantDTO", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.CustomerDTO", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.EmployeeDTO", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItemDTO", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderDTO", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.ReservationDTO", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.RestaurantDTO", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.TableDTO", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
