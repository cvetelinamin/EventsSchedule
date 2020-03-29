using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsSchedule.Data.Migrations
{
    public partial class ModifiedAddressesAndOrganizers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Organizers_OrganizerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OrganizerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizerId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrganizerId",
                table: "Addresses",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Organizers_OrganizerId",
                table: "Addresses",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
