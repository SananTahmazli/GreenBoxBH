using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CreateDatabaseForGreenBoxBH : Migration
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "About", "CountOfPages", "CreatedTime", "CreatedUserId", "ImagePath", "Name", "Price", "UpdatedTime", "UpdatedUserId" },
                values: new object[] { 1, "About", 2, new DateTime(2022, 12, 12, 15, 14, 53, 7, DateTimeKind.Utc).AddTicks(9717), 1, "~/images/product/book-1.png", "Book-1", 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "Name", "UpdatedTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 12, 15, 14, 53, 7, DateTimeKind.Utc).AddTicks(8758), 1, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2022, 12, 12, 15, 14, 53, 7, DateTimeKind.Utc).AddTicks(8786), 1, "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedTime", "CreatedUserId", "Email", "FullName", "Hash", "RoleId", "Salt", "UpdatedTime", "UpdatedUserId", "Username" },
                values: new object[] { 1, new DateTime(2022, 12, 12, 15, 14, 53, 7, DateTimeKind.Utc).AddTicks(9260), new DateTime(2022, 12, 12, 15, 14, 53, 7, DateTimeKind.Utc).AddTicks(9688), 1, "admin@gmail.com", "AdminAdmin", "ntu\n��^X�C�m�/cb9�T��8�|\\U|�", 1, "rNZruxC5d2IrZPm8yGFyGOI2Mg8JbMZTFEXmHzHzVmUZd+vopsnpEqnGvtogdwfoQu8N2lsoyOFh8zqQG9N3pcQZFUiVRQY/5+TFpjzg4XuMOmX+Hv7huTeP4es4Q54qtKZIRxAv9lqzGD3AdyOE65mNxYiVDwEpLZ12Wue5dtN03PL6/I87BziNFXisnKJpql005wbBNFRyQkwbvTlsQCRNHkGg6VWMuzfcUtDq7PvyxNEsIqJ0eixWj3Sx6AEx33B21pMNQ5/5iZ34bDeh8Ero8eXlVpyJDO54PPcMdCWIVizRLtv7hxCkD/NyXY76Wy5j6dYPc468EKyUEzF6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
