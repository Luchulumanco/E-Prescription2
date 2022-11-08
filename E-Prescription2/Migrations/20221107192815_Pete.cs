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
                name: "Conditions",
                schema: "Identity",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICD_10_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionId);
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
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "MedicationInteractions",
                schema: "Identity",
                columns: table => new
                {
                    MediInteractionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveOne = table.Column<int>(type: "int", nullable: true),
                    ActiveTwo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationInteractions", x => x.MediInteractionId);
                    table.ForeignKey(
                        name: "FK_MedicationInteractions_ActiveIngredientRecords_ActiveOne",
                        column: x => x.ActiveOne,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_MedicationInteractions_ActiveIngredientRecords_ActiveTwo",
                        column: x => x.ActiveTwo,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                });

            migrationBuilder.CreateTable(
                name: "ContraIndications",
                schema: "Identity",
                columns: table => new
                {
                    ContraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraIndications", x => x.ContraId);
                    table.ForeignKey(
                        name: "FK_ContraIndications_ActiveIngredientRecords_ActiveIngredientId",
                        column: x => x.ActiveIngredientId,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContraIndications_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "Identity",
                        principalTable: "Conditions",
                        principalColumn: "ConditionId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "MedicationActiveIngredient",
                schema: "Identity",
                columns: table => new
                {
                    MediActiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveIngredientId1 = table.Column<int>(type: "int", nullable: true),
                    ActiveIngredientId2 = table.Column<int>(type: "int", nullable: true),
                    ActiveIngredientId3 = table.Column<int>(type: "int", nullable: true),
                    ActiveIngredientId4 = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    DosageFormId = table.Column<int>(type: "int", nullable: true),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationActiveIngredient", x => x.MediActiveId);
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredientRecords_ActiveIngredientId1",
                        column: x => x.ActiveIngredientId1,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredientRecords_ActiveIngredientId2",
                        column: x => x.ActiveIngredientId2,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredientRecords_ActiveIngredientId3",
                        column: x => x.ActiveIngredientId3,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_MedicationActiveIngredient_ActiveIngredientRecords_ActiveIngredientId4",
                        column: x => x.ActiveIngredientId4,
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
                        name: "FK_MedicationActiveIngredient_Schedule_ScheduleId",
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
                name: "MedicalPracticeRecords",
                schema: "Identity",
                columns: table => new
                {
                    PracticeNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    SuburbId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPracticeRecords", x => x.PracticeNumberId);
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
                    MedicalPracticeRecordsPracticeNumberId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AspNetUsers_MedicalPracticeRecords_MedicalPracticeRecordsPracticeNumberId",
                        column: x => x.MedicalPracticeRecordsPracticeNumberId,
                        principalSchema: "Identity",
                        principalTable: "MedicalPracticeRecords",
                        principalColumn: "PracticeNumberId");
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
                name: "ChricConditions",
                schema: "Identity",
                columns: table => new
                {
                    ChronicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChricConditions", x => x.ChronicId);
                    table.ForeignKey(
                        name: "FK_ChricConditions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChricConditions_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "Identity",
                        principalTable: "Conditions",
                        principalColumn: "ConditionId");
                });

            migrationBuilder.CreateTable(
                name: "ChronicMedications",
                schema: "Identity",
                columns: table => new
                {
                    ChronicMedi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MedicationId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicMedications", x => x.ChronicMedi);
                    table.ForeignKey(
                        name: "FK_ChronicMedications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChronicMedications_MedicationActiveIngredient_MedicationId",
                        column: x => x.MedicationId,
                        principalSchema: "Identity",
                        principalTable: "MedicationActiveIngredient",
                        principalColumn: "MediActiveId");
                });

            migrationBuilder.CreateTable(
                name: "DrugAllergies",
                schema: "Identity",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugAllergies", x => x.DrugId);
                    table.ForeignKey(
                        name: "FK_DrugAllergies_ActiveIngredientRecords_ActiveIngredientId",
                        column: x => x.ActiveIngredientId,
                        principalSchema: "Identity",
                        principalTable: "ActiveIngredientRecords",
                        principalColumn: "ActiveIngredientId");
                    table.ForeignKey(
                        name: "FK_DrugAllergies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    SuburbId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "DispenseDetails",
                schema: "Identity",
                columns: table => new
                {
                    DispenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PharmacistId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    RepeatsLeft = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenseDetails", x => x.DispenseId);
                    table.ForeignKey(
                        name: "FK_DispenseDetails_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DispenseDetails_PharmacyRecords_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Identity",
                        principalTable: "PharmacyRecords",
                        principalColumn: "PharmacyId");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionLines",
                schema: "Identity",
                columns: table => new
                {
                    PrescriptionLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationId = table.Column<int>(type: "int", nullable: true),
                    DispenseId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionLines", x => x.PrescriptionLineId);
                    table.ForeignKey(
                        name: "FK_PrescriptionLines_DispenseDetails_DispenseId",
                        column: x => x.DispenseId,
                        principalSchema: "Identity",
                        principalTable: "DispenseDetails",
                        principalColumn: "DispenseId");
                    table.ForeignKey(
                        name: "FK_PrescriptionLines_MedicationActiveIngredient_MedicationId",
                        column: x => x.MedicationId,
                        principalSchema: "Identity",
                        principalTable: "MedicationActiveIngredient",
                        principalColumn: "MediActiveId");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                schema: "Identity",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    prescriptionLineId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescriptions_AspNetUsers_PatientID",
                        column: x => x.PatientID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescriptions_PrescriptionLines_prescriptionLineId",
                        column: x => x.prescriptionLineId,
                        principalSchema: "Identity",
                        principalTable: "PrescriptionLines",
                        principalColumn: "PrescriptionLineId");
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
                name: "IX_AspNetUsers_MedicalPracticeRecordsPracticeNumberId",
                schema: "Identity",
                table: "AspNetUsers",
                column: "MedicalPracticeRecordsPracticeNumberId");

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
                name: "IX_ChricConditions_ConditionId",
                schema: "Identity",
                table: "ChricConditions",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChricConditions_UserId",
                schema: "Identity",
                table: "ChricConditions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicMedications_MedicationId",
                schema: "Identity",
                table: "ChronicMedications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicMedications_UserId",
                schema: "Identity",
                table: "ChronicMedications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "Identity",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndications_ActiveIngredientId",
                schema: "Identity",
                table: "ContraIndications",
                column: "ActiveIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndications_ConditionId",
                schema: "Identity",
                table: "ContraIndications",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseDetails_PharmacistId",
                schema: "Identity",
                table: "DispenseDetails",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseDetails_PharmacyId",
                schema: "Identity",
                table: "DispenseDetails",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugAllergies_ActiveIngredientId",
                schema: "Identity",
                table: "DrugAllergies",
                column: "ActiveIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugAllergies_UserId",
                schema: "Identity",
                table: "DrugAllergies",
                column: "UserId");

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
                name: "IX_MedicationActiveIngredient_ActiveIngredientId1",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientId1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ActiveIngredientId2",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientId2");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ActiveIngredientId3",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientId3");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ActiveIngredientId4",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ActiveIngredientId4");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_DosageFormId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "DosageFormId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActiveIngredient_ScheduleId",
                schema: "Identity",
                table: "MedicationActiveIngredient",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationInteractions_ActiveOne",
                schema: "Identity",
                table: "MedicationInteractions",
                column: "ActiveOne");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationInteractions_ActiveTwo",
                schema: "Identity",
                table: "MedicationInteractions",
                column: "ActiveTwo");

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
                name: "IX_PrescriptionLines_DispenseId",
                schema: "Identity",
                table: "PrescriptionLines",
                column: "DispenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionLines_MedicationId",
                schema: "Identity",
                table: "PrescriptionLines",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                schema: "Identity",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientID",
                schema: "Identity",
                table: "Prescriptions",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_prescriptionLineId",
                schema: "Identity",
                table: "Prescriptions",
                column: "prescriptionLineId");

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
                name: "ChricConditions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ChronicMedications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ContraIndications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DrugAllergies",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MedicationInteractions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Prescriptions",
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
                name: "Conditions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PrescriptionLines",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DispenseDetails",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MedicationActiveIngredient",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PharmacyRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActiveIngredientRecords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DosageForms",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
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
