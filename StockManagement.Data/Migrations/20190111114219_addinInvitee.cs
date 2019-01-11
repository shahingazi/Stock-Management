using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.Data.Migrations
{
    public partial class addinInvitee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InviteeId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteeId",
                table: "Users");
        }
    }
}
