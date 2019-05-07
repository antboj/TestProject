using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Upgraded_To_Abp_v340 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "ClaimType",
                "AbpUserClaims",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "UserName",
                "AbpUserAccounts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "EmailAddress",
                "AbpUserAccounts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "ClaimType",
                "AbpRoleClaims",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                "AbpEntityChangeSets",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpEntityChanges",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        x => x.EntityChangeSetId,
                        "AbpEntityChangeSets",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpEntityPropertyChanges",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        x => x.EntityChangeId,
                        "AbpEntityChanges",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityChangeSetId",
                "AbpEntityChanges",
                "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                "AbpEntityChanges",
                new[] {"EntityTypeFullName", "EntityId"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_CreationTime",
                "AbpEntityChangeSets",
                new[] {"TenantId", "CreationTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_Reason",
                "AbpEntityChangeSets",
                new[] {"TenantId", "Reason"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_UserId",
                "AbpEntityChangeSets",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityPropertyChanges_EntityChangeId",
                "AbpEntityPropertyChanges",
                "EntityChangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                "AbpEntityChanges");

            migrationBuilder.DropTable(
                "AbpEntityChangeSets");

            migrationBuilder.AlterColumn<string>(
                "ClaimType",
                "AbpUserClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "UserName",
                "AbpUserAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "EmailAddress",
                "AbpUserAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "ClaimType",
                "AbpRoleClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}