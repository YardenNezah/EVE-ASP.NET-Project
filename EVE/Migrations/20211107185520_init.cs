using Microsoft.EntityFrameworkCore.Migrations;

namespace EVE.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Memberid = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_Member_Memberid",
                        column: x => x.Memberid,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FavoriteId",
                table: "Product",
                column: "FavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_Memberid",
                table: "Favorite",
                column: "Memberid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Favorite_FavoriteId",
                table: "Product",
                column: "FavoriteId",
                principalTable: "Favorite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Favorite_FavoriteId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Product_FavoriteId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FavoriteId",
                table: "Product");
        }
    }
}
