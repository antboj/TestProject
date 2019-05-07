using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Upgrade_ABP_4_2_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "LastLoginTime",
                "AbpUsers");

            migrationBuilder.DropColumn(
                "LastLoginTime",
                "AbpUserAccounts");

            migrationBuilder.AddColumn<string>(
                "ReturnValue",
                "AbpAuditLogs",
                nullable: true);

            migrationBuilder.CreateTable(
                "AbpOrganizationUnitRoles",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                "AbpOrganizationUnitRoles",
                new[] {"TenantId", "OrganizationUnitId"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                "AbpOrganizationUnitRoles",
                new[] {"TenantId", "RoleId"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpOrganizationUnitRoles");

            migrationBuilder.DropColumn(
                "ReturnValue",
                "AbpAuditLogs");

            migrationBuilder.AddColumn<DateTime>(
                "LastLoginTime",
                "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "LastLoginTime",
                "AbpUserAccounts",
                nullable: true);
        }
    }
}