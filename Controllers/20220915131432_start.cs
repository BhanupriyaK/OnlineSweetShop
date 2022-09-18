using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop1.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "prodID",
                table: "offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_offers_Productid",
                table: "offers",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_offers_sweetProducts_Productid",
                table: "offers",
                column: "Productid",
                principalTable: "sweetProducts",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_offers_sweetProducts_Productid",
                table: "offers");

            migrationBuilder.DropIndex(
                name: "IX_offers_Productid",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "offers");

            migrationBuilder.AlterColumn<string>(
                name: "prodID",
                table: "offers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
