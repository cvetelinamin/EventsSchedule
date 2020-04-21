using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsSchedule.Data.Migrations
{
    public partial class AddedImageColumnForEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Events",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EventCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EventCategories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
