using Microsoft.EntityFrameworkCore.Migrations;

namespace SSTFU_V2.Migrations
{
    public partial class init03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "SportObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObjectCategoryId",
                table: "SportObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "RentPlaces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ObjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportObjects_ObjectCategoryId",
                table: "SportObjects",
                column: "ObjectCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportObjects_ObjectCategories_ObjectCategoryId",
                table: "SportObjects",
                column: "ObjectCategoryId",
                principalTable: "ObjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportObjects_ObjectCategories_ObjectCategoryId",
                table: "SportObjects");

            migrationBuilder.DropTable(
                name: "ObjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_SportObjects_ObjectCategoryId",
                table: "SportObjects");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "SportObjects");

            migrationBuilder.DropColumn(
                name: "ObjectCategoryId",
                table: "SportObjects");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "RentPlaces");
        }
    }
}
