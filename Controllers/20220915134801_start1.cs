using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop1.Migrations
{
    public partial class start1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_offers_prodID",
                table: "offers",
                column: "prodID");

            migrationBuilder.AddForeignKey(
                name: "FK_offers_sweetProducts_prodID",
                table: "offers",
                column: "prodID",
                principalTable: "sweetProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_offers_sweetProducts_prodID",
                table: "offers");

            migrationBuilder.DropIndex(
                name: "IX_offers_prodID",
                table: "offers");

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
    }
}
