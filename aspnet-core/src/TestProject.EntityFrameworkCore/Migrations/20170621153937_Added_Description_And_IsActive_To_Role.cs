using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Added_Description_And_IsActive_To_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Description",
                "AbpRoles",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "IsActive",
                "AbpRoles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Description",
                "AbpRoles");

            migrationBuilder.DropColumn(
                "IsActive",
                "AbpRoles");
        }
    }
}