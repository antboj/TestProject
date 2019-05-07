using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DeviceTypes",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                    table.ForeignKey(
                        "FK_DeviceTypes_DeviceTypes_ParentId",
                        x => x.ParentId,
                        "DeviceTypes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Devices",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DeviceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        "FK_Devices_DeviceTypes_DeviceTypeId",
                        x => x.DeviceTypeId,
                        "DeviceTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DeviceTypeProperties",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsMandatory = table.Column<bool>(nullable: false),
                    MachineKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_DeviceTypeProperties_DeviceTypes_DeviceTypeId",
                        x => x.DeviceTypeId,
                        "DeviceTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DevicePropertyValues",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceTypePropertyId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePropertyValues", x => x.Id);
                    table.ForeignKey(
                        "FK_DevicePropertyValues_Devices_DeviceId",
                        x => x.DeviceId,
                        "Devices",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DevicePropertyValues_DeviceTypeProperties_DeviceTypePropertyId",
                        x => x.DeviceTypePropertyId,
                        "DeviceTypeProperties",
                        "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                "IX_DevicePropertyValues_DeviceId",
                "DevicePropertyValues",
                "DeviceId");

            migrationBuilder.CreateIndex(
                "IX_DevicePropertyValues_DeviceTypePropertyId",
                "DevicePropertyValues",
                "DeviceTypePropertyId");

            migrationBuilder.CreateIndex(
                "IX_Devices_DeviceTypeId",
                "Devices",
                "DeviceTypeId");

            migrationBuilder.CreateIndex(
                "IX_DeviceTypeProperties_DeviceTypeId",
                "DeviceTypeProperties",
                "DeviceTypeId");

            migrationBuilder.CreateIndex(
                "IX_DeviceTypes_ParentId",
                "DeviceTypes",
                "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DevicePropertyValues");

            migrationBuilder.DropTable(
                "Devices");

            migrationBuilder.DropTable(
                "DeviceTypeProperties");

            migrationBuilder.DropTable(
                "DeviceTypes");
        }
    }
}