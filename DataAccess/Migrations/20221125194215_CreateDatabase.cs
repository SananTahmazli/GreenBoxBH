using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    About = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    CountOfPages = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "About", "CountOfPages", "CreatedTime", "CreatedUserId", "ImagePath", "Name", "Price", "UpdatedTime", "UpdatedUserId" },
                values: new object[] { 1, "About", 2, new DateTime(2022, 11, 25, 19, 42, 15, 341, DateTimeKind.Utc).AddTicks(6982), 1, "~/images/product/book-1.png", "Book-1", 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedTime", "CreatedUserId", "Email", "FullName", "Hash", "Salt", "UpdatedTime", "UpdatedUserId", "Username" },
                values: new object[] { 1, new DateTime(2022, 11, 25, 19, 42, 15, 341, DateTimeKind.Utc).AddTicks(6265), new DateTime(2022, 11, 25, 19, 42, 15, 341, DateTimeKind.Utc).AddTicks(6854), 1, "admin@gmail.com", "AdminAdmin", "�$3\"�qw>+��Z��\"sySle�P:�*?�", "+jlsinWbE3KkexaI8iqZ0WurgYE3ELg20HlojwEhnVv+h7QlL28jj7vFcSFAIKfDEoW/GQq8v+0wTmyKws1k59HZTfFul/SUxZ0QdJSZdjloqE4yAuGu0ByIKYA0aVZq7jXAEPDf3Q6sSL4LtRKIV/0Tn+YcylZ+koxwTlWv1145YUu1FX6+m18EnnijJJTzGxdoRIp5odH2fcq+AcPCI/8geDIS2AoIGhNPacuwKwxGbJdIrmYLkx98YKFYQfjDbJX1Wd8BGyHgPNDkFhGfcQahy4zTndQcywPZTXIYY6M2zzRZ3E5JBPPcn3cSPVM9HNhy8IUE11ZnOj4KBdv8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
