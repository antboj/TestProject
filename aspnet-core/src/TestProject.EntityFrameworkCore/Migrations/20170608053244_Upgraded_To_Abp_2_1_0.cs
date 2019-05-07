using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Upgraded_To_Abp_2_1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AbpRoleClaims_AbpRoles_UserId",
                "AbpRoleClaims");

            migrationBuilder.DropIndex(
                "IX_AbpRoleClaims_UserId",
                "AbpRoleClaims");

            migrationBuilder.DropColumn(
                "UserId",
                "AbpRoleClaims");

            migrationBuilder.AddColumn<bool>(
                "IsDisabled",
                "AbpLanguages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                "FK_AbpRoleClaims_AbpRoles_RoleId",
                "AbpRoleClaims",
                "RoleId",
                "AbpRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AbpRoleClaims_AbpRoles_RoleId",
                "AbpRoleClaims");

            migrationBuilder.DropColumn(
                "IsDisabled",
                "AbpLanguages");

            migrationBuilder.AddColumn<int>(
                "UserId",
                "AbpRoleClaims",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_UserId",
                "AbpRoleClaims",
                "UserId");

            migrationBuilder.AddForeignKey(
                "FK_AbpRoleClaims_AbpRoles_UserId",
                "AbpRoleClaims",
                "UserId",
                "AbpRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}