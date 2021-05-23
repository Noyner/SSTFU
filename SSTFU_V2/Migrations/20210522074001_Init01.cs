using Microsoft.EntityFrameworkCore.Migrations;

namespace SSTFU_V2.Migrations
{
    public partial class Init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coords = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportInventoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportInventoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    banFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "SportInventorry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfStorage = table.Column<int>(type: "int", nullable: false),
                    RentPlaceId = table.Column<int>(type: "int", nullable: true),
                    SportObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportInventorry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportInventorry_RentPlaces_RentPlaceId",
                        column: x => x.RentPlaceId,
                        principalTable: "RentPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportInventorry_SportInventoryTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "SportInventoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportInventorry_SportObjects_SportObjectId",
                        column: x => x.SportObjectId,
                        principalTable: "SportObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportInventorry_RentPlaceId",
                table: "SportInventorry",
                column: "RentPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SportInventorry_SportObjectId",
                table: "SportInventorry",
                column: "SportObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SportInventorry_TypeId",
                table: "SportInventorry",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportInventorry");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RentPlaces");

            migrationBuilder.DropTable(
                name: "SportInventoryTypes");

            migrationBuilder.DropTable(
                name: "SportObjects");
        }
    }
}
