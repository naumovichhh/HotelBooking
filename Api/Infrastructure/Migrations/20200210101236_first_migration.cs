using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    Locality = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Picture = table.Column<string>(maxLength: 100, nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Token = table.Column<string>(maxLength: 50, nullable: false),
                    ExpiredTime = table.Column<DateTime>(nullable: false),
                    IsStopped = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Role = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    RegistrationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Salt = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalService_Hotel",
                        column: x => x.Hotel,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel = table.Column<int>(nullable: false),
                    AdultPlaces = table.Column<int>(nullable: false),
                    ChildPlaces = table.Column<int>(nullable: false),
                    BedsDescription = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomType_Hotel",
                        column: x => x.Hotel,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType",
                        column: x => x.Type,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomType/RoomFeature",
                columns: table => new
                {
                    Feature = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType/RoomFeature", x => new { x.Feature, x.RoomType });
                    table.ForeignKey(
                        name: "FK_RoomType/RoomFeature_RoomFeature",
                        column: x => x.Feature,
                        principalTable: "RoomFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomType/RoomFeature_RoomType",
                        column: x => x.RoomType,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room = table.Column<int>(nullable: false),
                    User = table.Column<string>(maxLength: 30, nullable: false),
                    From = table.Column<DateTime>(type: "date", nullable: false),
                    To = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Room",
                        column: x => x.Room,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking/Service",
                columns: table => new
                {
                    Booking = table.Column<int>(nullable: false),
                    Service = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking/Service", x => new { x.Booking, x.Service });
                    table.ForeignKey(
                        name: "FK_Booking/Service_Booking",
                        column: x => x.Booking,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking/Service_AdditionalService",
                        column: x => x.Service,
                        principalTable: "AdditionalService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalService_Hotel",
                table: "AdditionalService",
                column: "Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Room",
                table: "Booking",
                column: "Room");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_User",
                table: "Booking",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Booking/Service_Service",
                table: "Booking/Service",
                column: "Service");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Type",
                table: "Room",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_Hotel",
                table: "RoomType",
                column: "Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType/RoomFeature_RoomType",
                table: "RoomType/RoomFeature",
                column: "RoomType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking/Service");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RoomType/RoomFeature");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "AdditionalService");

            migrationBuilder.DropTable(
                name: "RoomFeature");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
