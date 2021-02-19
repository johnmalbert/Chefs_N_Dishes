using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class AddedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefNameChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefNameChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefNameChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefNameChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefNameChefId",
                table: "Dishes",
                column: "ChefNameChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefNameChefId",
                table: "Dishes",
                column: "ChefNameChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
