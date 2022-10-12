using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Prescription2.Migrations
{
    public partial class Pete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "ActiveIngredientRecords",
                schema: "Identity",
                columns: table => new
                {
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveIngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredientRecords", x => x.ActiveIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "DosageForms",
                schema: "Identity",
                columns: table => new
                {
                    DosageFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageFormName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageForms", x => x.DosageFormId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Identity",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                schema: "Identity",
                columns: table => new
                {
                    PostalCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.PostalCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "Identity",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "Identity",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Identity",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Identity",
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRecords",
                schema: "Identity",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    DosageFormId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRecords", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_MedicationRecords_DosageForms_DosageFormId",
                        column: x => x.DosageFormId,
                        principalSchema: "Identity",
                        principalTable: "DosageForms",
                        principalColumn: "DosageFormId");
                    table.ForeignKey(
                        name: "FK_MedicationRecords_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "Identity",
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                schema: "Identity",
                columns: table => new
                {
                    SuburbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.SuburbId);
                    table.ForeignKey(
                        name: "FK_Suburbs_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Identity",
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suburbs_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalSchema: "Identity",
                        principalTable: "PostalCodes",
                        principalColumn: "PostalCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationActiveIngredient",
                schema: "Identity",
                columns: table => new
                {
                    MediActiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationId = table.Column<int>(type: "int", nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    DosageFormId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationActiveIngredient", x => x.MediActiveId);
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredientRecords_ActiveIngredientId",
                        column: x => x.ActiveIngredientId,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_DosageForms_DosageFormId",
                        column: x => x.DosageFormId,
                        principalSchema: "Identity",
                        principalTable: "DosageForms",
                        principalColumn: "DosageFormId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_MedicationRecords_MedicationId",
                        column: x => x.MedicationId,
                        principalSchema: "Identity",
                        principalTable: "MedicationRecords",
                        principalColumn: "MedicationId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "Identity",
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalPracticeRecords",
                schema: "Identity",
                columns: table => new
                {
                    PracticeNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    SuburbId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPracticeRecords", x => x.PracticeNumber);
                    table.ForeignKey(
                        name: "FK_MedicalPracticeRecords_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Identity",
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_MedicalPracticeRecords_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalSchema: "Identity",
                        principalTable: "PostalCodes",
                        principalColumn: "PostalCodeId");
                    table.ForeignKey(
                        name: "FK_MedicalPracticeRecords_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Identity",
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                    table.ForeignKey(
                        name: "FK_MedicalPracticeRecords_Suburbs_SuburbId",
                        column: x => x.SuburbId,
                        principalSchema: "Identity",
                        principalTable: "Suburbs",
                        principalColumn: "SuburbId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    SuburbId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeNumber = table.Column<int>(type: "int", nullable: true),
                    MedicalPracticeRecordsPracticeNumber = table.Column<int>(type: "int", nullable: true),
                    HealthCouncilRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Identity",
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "Identity",
                        principalTable: "Genders",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_MedicalPracticeRecords_MedicalPracticeRecordsPracticeNumber",
                        column: x => x.MedicalPracticeRecordsPracticeNumber,
                        principalSchema: "Identity",
                        principalTable: "MedicalPracticeRecords",
                        principalColumn: "PracticeNumber");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalSchema: "Identity",
                        principalTable: "PostalCodes",
                        principalColumn: "PostalCodeId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Identity",
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Suburbs_SuburbId",
                        column: x => x.SuburbId,
                        principalSchema: "Identity",
                        principalTable: "Suburbs",
                        principalColumn: "SuburbId");
                });

            migrationBuilder.CreateTable(
                name: "PharmacyRecords",
                schema: "Identity",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    SuburbId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyRecords", x => x.PharmacyId);
                    table.ForeignKey(
                        name: "FK_PharmacyRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PharmacyRecords_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Identity",
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_PharmacyRecords_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalSchema: "Identity",
                        principalTable: "PostalCodes",
                        principalColumn: "PostalCodeId");
                    table.ForeignKey(
                        name: "FK_PharmacyRecords_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Identity",
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                    table.ForeignKey(
                        name: "FK_PharmacyRecords_Suburbs_SuburbId",
                        column: x => x.SuburbId,
                        principalSchema: "Identity",
                        principalTable: "Suburbs",
                        principalColumn: "SuburbId");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalPracticeRecordsPracticeNumber",
                schema: "Identity",
                table: "AspNetUsers",
                column: "MedicalPracticeRecordsPracticeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PostalCodeId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProvinceId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "Identity",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPracticeRecords_CityId",
                schema: "Identity",
                table: "MedicalPracticeRecords",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPracticeRecords_PostalCodeId",
                schema: "Identity",
                table: "MedicalPracticeRecords",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPracticeRecords_ProvinceId",
                schema: "Identity",
                table: "MedicalPracticeRecords",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPracticeRecords_SuburbId",
                schema: "Identity",
                table: "MedicalPracticeRecords",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ActiveIngredientId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_DosageFormId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "DosageFormId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_MedicationId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ScheduleId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecords_DosageFormId",
                schema: "Identity",
                table: "MedicationRecords",
                column: "DosageFormId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecords_ScheduleId",
                schema: "Identity",
                table: "MedicationRecords",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRecords_CityId",
                schema: "Identity",
                table: "PharmacyRecords",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRecords_PostalCodeId",
                schema: "Identity",
                table: "PharmacyRecords",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRecords_ProvinceId",
                schema: "Identity",
                table: "PharmacyRecords",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRecords_SuburbId",
                schema: "Identity",
                table: "PharmacyRecords",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRecords_UserId",
                schema: "Identity",
                table: "PharmacyRecords",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityId",
                schema: "Identity",
                table: "Suburbs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_PostalCodeId",
                schema: "Identity",
                table: "Suburbs",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationActiveIngredient",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PharmacyRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActiveIngredientRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MedicationRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DosageForms",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MedicalPracticeRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Suburbs",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PostalCodes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "Identity");
        }
    }
}
