using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class Initial_Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AbpEditions",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpEditions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpAuditLogs",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpAuditLogs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserAccounts",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserAccounts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserLoginAttempts",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserOrganizationUnits",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpBackgroundJobs",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<byte>(nullable: false),
                    TryCount = table.Column<short>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguages",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpLanguages", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguageTexts",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    LanguageName = table.Column<string>(maxLength: 10, nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotifications",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Severity = table.Column<byte>(nullable: false),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotificationSubscriptions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpTenantNotifications",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Severity = table.Column<byte>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserNotifications",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnits",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        x => x.ParentId,
                        "AbpOrganizationUnits",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpUsers",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(maxLength: 32, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpFeatures",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    EditionId = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpFeatures_AbpEditions_EditionId",
                        x => x.EditionId,
                        "AbpEditions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserClaims",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserClaims_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserLogins",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserLogins_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserRoles",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserRoles_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserTokens",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserTokens_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpSettings",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Value = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpSettings_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpRoles",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpTenants",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EditionId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpEditions_EditionId",
                        x => x.EditionId,
                        "AbpEditions",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpPermissions",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpPermissions_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AbpPermissions_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpRoleClaims",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpRoleClaims_AbpRoles_UserId",
                        x => x.UserId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_AbpFeatures_EditionId_Name",
                "AbpFeatures",
                new[] {"EditionId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpFeatures_TenantId_Name",
                "AbpFeatures",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                "AbpAuditLogs",
                new[] {"TenantId", "ExecutionDuration"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionTime",
                "AbpAuditLogs",
                new[] {"TenantId", "ExecutionTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_UserId",
                "AbpAuditLogs",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_TenantId_Name",
                "AbpPermissions",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_RoleId",
                "AbpPermissions",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_UserId",
                "AbpPermissions",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_RoleId",
                "AbpRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_UserId",
                "AbpRoleClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_TenantId_ClaimType",
                "AbpRoleClaims",
                new[] {"TenantId", "ClaimType"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_EmailAddress",
                "AbpUserAccounts",
                "EmailAddress");

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_UserName",
                "AbpUserAccounts",
                "UserName");

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_EmailAddress",
                "AbpUserAccounts",
                new[] {"TenantId", "EmailAddress"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserId",
                "AbpUserAccounts",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserName",
                "AbpUserAccounts",
                new[] {"TenantId", "UserName"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_UserId",
                "AbpUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_TenantId_ClaimType",
                "AbpUserClaims",
                new[] {"TenantId", "ClaimType"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_UserId",
                "AbpUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_UserId",
                "AbpUserLogins",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                "AbpUserLogins",
                new[] {"TenantId", "LoginProvider", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_UserId_TenantId",
                "AbpUserLoginAttempts",
                new[] {"UserId", "TenantId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result",
                "AbpUserLoginAttempts",
                new[] {"TenancyName", "UserNameOrEmailAddress", "Result"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                "AbpUserOrganizationUnits",
                new[] {"TenantId", "OrganizationUnitId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_UserId",
                "AbpUserOrganizationUnits",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_UserId",
                "AbpUserRoles",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_RoleId",
                "AbpUserRoles",
                new[] {"TenantId", "RoleId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_UserId",
                "AbpUserRoles",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserTokens_UserId",
                "AbpUserTokens",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserTokens_TenantId_UserId",
                "AbpUserTokens",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                "AbpBackgroundJobs",
                new[] {"IsAbandoned", "NextTryTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_UserId",
                "AbpSettings",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_TenantId_Name",
                "AbpSettings",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpLanguages_TenantId_Name",
                "AbpLanguages",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                "AbpLanguageTexts",
                new[] {"TenantId", "Source", "LanguageName", "Key"});

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId",
                "AbpNotificationSubscriptions",
                new[] {"NotificationName", "EntityTypeName", "EntityId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId",
                "AbpNotificationSubscriptions",
                new[] {"TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpTenantNotifications_TenantId",
                "AbpTenantNotifications",
                "TenantId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserNotifications_UserId_State_CreationTime",
                "AbpUserNotifications",
                new[] {"UserId", "State", "CreationTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_ParentId",
                "AbpOrganizationUnits",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_TenantId_Code",
                "AbpOrganizationUnits",
                new[] {"TenantId", "Code"});

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_CreatorUserId",
                "AbpRoles",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_DeleterUserId",
                "AbpRoles",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_LastModifierUserId",
                "AbpRoles",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_TenantId_NormalizedName",
                "AbpRoles",
                new[] {"TenantId", "NormalizedName"});

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_CreatorUserId",
                "AbpUsers",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_DeleterUserId",
                "AbpUsers",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_LastModifierUserId",
                "AbpUsers",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                "AbpUsers",
                new[] {"TenantId", "NormalizedEmailAddress"});

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedUserName",
                "AbpUsers",
                new[] {"TenantId", "NormalizedUserName"});

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_CreatorUserId",
                "AbpTenants",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_DeleterUserId",
                "AbpTenants",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_EditionId",
                "AbpTenants",
                "EditionId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_LastModifierUserId",
                "AbpTenants",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_TenancyName",
                "AbpTenants",
                "TenancyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpFeatures");

            migrationBuilder.DropTable(
                "AbpAuditLogs");

            migrationBuilder.DropTable(
                "AbpPermissions");

            migrationBuilder.DropTable(
                "AbpRoleClaims");

            migrationBuilder.DropTable(
                "AbpUserAccounts");

            migrationBuilder.DropTable(
                "AbpUserClaims");

            migrationBuilder.DropTable(
                "AbpUserLogins");

            migrationBuilder.DropTable(
                "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                "AbpUserRoles");

            migrationBuilder.DropTable(
                "AbpUserTokens");

            migrationBuilder.DropTable(
                "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                "AbpSettings");

            migrationBuilder.DropTable(
                "AbpLanguages");

            migrationBuilder.DropTable(
                "AbpLanguageTexts");

            migrationBuilder.DropTable(
                "AbpNotifications");

            migrationBuilder.DropTable(
                "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                "AbpTenantNotifications");

            migrationBuilder.DropTable(
                "AbpUserNotifications");

            migrationBuilder.DropTable(
                "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                "AbpTenants");

            migrationBuilder.DropTable(
                "AbpRoles");

            migrationBuilder.DropTable(
                "AbpEditions");

            migrationBuilder.DropTable(
                "AbpUsers");
        }
    }
}