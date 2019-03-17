using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace userCase.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cityCode = table.Column<int>(nullable: false),
                    cityName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityID);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    districtID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    districtCode = table.Column<int>(maxLength: 100, nullable: false),
                    districtName = table.Column<string>(maxLength: 100, nullable: true),
                    cityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.districtID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    surname = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    districtID = table.Column<int>(nullable: false),
                    cityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_users_cities_cityID",
                        column: x => x.cityID,
                        principalTable: "cities",
                        principalColumn: "cityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_districts_districtID",
                        column: x => x.districtID,
                        principalTable: "districts",
                        principalColumn: "districtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "cityID", "cityCode", "cityName" },
                values: new object[,]
                {
                    { 1, 1, "Adana" },
                    { 2, 2, "Adıyaman" },
                    { 3, 3, "Afyon" },
                    { 4, 4, "Ağrı" },
                    { 5, 5, "Amasya" },
                    { 6, 34, "İstanbul" },
                    { 7, 35, "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "districts",
                columns: new[] { "districtID", "cityID", "districtCode", "districtName" },
                values: new object[,]
                {
                    { 9, 3, 1183, "BEŞİKTAŞ" },
                    { 8, 3, 1166, "BAKIRKÖY" },
                    { 7, 3, 1103, "ADALAR" },
                    { 6, 2, 1246, "ÇELİKHAN" },
                    { 2, 1, 1219, "CEYHAN" },
                    { 4, 2, 1105, "MERKEZ" },
                    { 3, 1, 1329, "FEKE" },
                    { 10, 3, 1203, "BORNOVA" },
                    { 1, 1, 1104, "SEYHAN" },
                    { 5, 2, 1182, "BESNİ" },
                    { 11, 3, 1251, "ÇEŞME" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_cityID",
                table: "users",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_users_districtID",
                table: "users",
                column: "districtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "districts");
        }
    }
}
