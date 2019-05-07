using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Upgraded_To_Abp_v3_9_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Surname",
                "AbpUsers",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AbpUsers",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Surname",
                "AbpUsers",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AbpUsers",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);
        }
    }
}