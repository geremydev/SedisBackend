using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SedisBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discapacities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HealthCenterCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthInsurances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PolicyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsuranceCompany = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CoverageLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TestCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Concentration = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RouteOfAdministration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Indications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Contraindications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Precautions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DrugInteractions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Presentation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "CHAR(1)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doses = table.Column<int>(type: "int", nullable: false),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationCoverages",
                columns: table => new
                {
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopayAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CoinsurancePercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PriorAuthorizationRequired = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCoverages", x => new { x.MedicationId, x.HealthInsuranceId });
                    table.ForeignKey(
                        name: "FK_MedicationCoverages_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationCoverages_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCenterServices",
                columns: table => new
                {
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenterServices", x => new { x.HealthCenterId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_HealthCenterServices_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthCenterServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistants_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assistants_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentlyWorkingHealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_HealthCenters_CurrentlyWorkingHealthCenterId",
                        column: x => x.CurrentlyWorkingHealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabTechs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTechs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTechs_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTechs_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrators_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registrators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalSpecialties",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalSpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalSpecialties", x => new { x.DoctorId, x.MedicalSpecialtyId });
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodTypeLabResultURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryCarePhysicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_PrimaryCarePhysicianId",
                        column: x => x.PrimaryCarePhysicianId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelativeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyHistories_Patients_RelativeId",
                        column: x => x.RelativeId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalConsultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalExamination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalConsultations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalConsultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientHealthInsurances",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHealthInsurances", x => new { x.PatientId, x.HealthInsuranceId });
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurances_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurances_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Allergen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => new { x.PatientId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientAllergies_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientDiscapacities",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscapacityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiscapacities", x => new { x.PatientId, x.DiscapacityId });
                    table.ForeignKey(
                        name: "FK_PatientDiscapacities_Discapacities_DiscapacityId",
                        column: x => x.DiscapacityId,
                        principalTable: "Discapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientDiscapacities_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientDiscapacities_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientIllnesses",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IllnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentURL = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DischargeDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Activo"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIllnesses", x => new { x.PatientId, x.IllnessId });
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientLabTestPrescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerformedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvalidationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTechId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLabTestPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientLabTestPrescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLabTestPrescriptions_LabTechs_LabTechId",
                        column: x => x.LabTechId,
                        principalTable: "LabTechs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLabTestPrescriptions_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLabTestPrescriptions_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientLabTestPrescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationPrescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationPrescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicationPrescription_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicationPrescription_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientMedicationPrescription_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicationPrescription_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientRiskFactors",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskFactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Activo"),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRiskFactors", x => new { x.PatientId, x.RiskFactorId });
                    table.ForeignKey(
                        name: "FK_PatientRiskFactors_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientRiskFactors_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientRiskFactors_RiskFactors_RiskFactorId",
                        column: x => x.RiskFactorId,
                        principalTable: "RiskFactors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientVaccines",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedDoses = table.Column<int>(type: "int", nullable: false),
                    LastApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<bool>(type: "bit", maxLength: 50, nullable: false, defaultValue: false),
                    MedicalConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVaccines", x => new { x.PatientId, x.VaccineId });
                    table.ForeignKey(
                        name: "FK_PatientVaccines_MedicalConsultations_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientVaccines_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientVaccines_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Description", "IcdCode", "Title" },
                values: new object[,]
                {
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), "Inflamación de las vías nasales provocada por alérgenos a los que la persona afectada ha sido previamente sensibilizada. Su patogenia es una alergia de tipo I en la mucosa nasal. Los antígenos inhalados en la mucosa nasal sensibilizada se unen a los anticuerpos IgE en los mastocitos, que liberan mediadores químicos como la histamina y péptido leucotrieno. Como consecuencia de ello, las terminales de las neuronas sensitivas y los vasos reaccionan para inducir estornudos, rinorrea y congestión nasal (reacción de la fase inmediata). En la reacción de la fase tardía, los mastocitos producen diversos mediadores químicos, lo linfocitos Th2 y los mastocitos producen citocinas, y las células epiteliales, las células endoteliales vasculares y los fibrocitos producen quimiocinas. Estos transmisores derivados de células realmente inducen infiltración de la mucosa nasal por células inflamatorias de diversos tipos. Entre estos tipos celulares, los eosinófilos activados son los principales responsables de la inflamación de la mucosa y la hiperreactividad.\r\n", "CA08", "Rinitis alérgica" },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), "Efectos adversos de los alimentos o los aditivos alimentarios que se asemejan clínicamente a la alergia. La alergia alimentaria es una reacción adversa a los alimentos mediada por un mecanismo inmunitario, ya sea con implicación de IgE específica (mediada por IgE), mecanismos mediados por células (no mediada por IgE) o mecanismos mixtos mediados tanto por células como por IgE.", "4A85.2", "Hipersensibilidad alimentaria" }
                });

            migrationBuilder.InsertData(
                table: "Discapacities",
                columns: new[] { "Id", "Description", "IcdCode", "Title" },
                values: new object[,]
                {
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), "Grupo de disfunciones visuales que implican interacciones con otros sistemas sensitivos y motores. Reflejan los efectos combinados en todas las etapas de procesamiento.\r\n", "9D93", "Disfunciones complejas relacionadas con la visión" },
                    { new Guid("5c52a9d3-6ee2-496e-a922-139de857d9d4"), "Hay genes dominantes y recesivos que pueden causar una discapacidad de leve a profunda. Si una familia posee un gen de la sordera dominante, el gen persistirá a lo largo de las generaciones porque basta con que se herede de un solo progenitor para que se manifieste en la descendencia. En cambio, si una familia tiene una discapacidad auditiva genética causada por un gen recesivo, este no siempre se manifestará, puesto que ello ocurre solo cuando ambos padres lo transmiten a sus descendientes. La discapacidad auditiva se produce antes de la adquisición del lenguaje por tratarse de una afección congénita.\r\n", "AB50", "Deficiencia auditiva congénita" }
                });

            migrationBuilder.InsertData(
                table: "HealthCenters",
                columns: new[] { "Id", "HealthCenterCategory", "LocationId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), "Specialized", new Guid("b2c3d4e5-f678-1234-5678-abcdef123456"), "Centro de Diagnóstico Médico (CDM)", true },
                    { new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), "General", new Guid("a1c1b2c3-d4e5-678f-1234-56789abcdef0"), "Hospital General Dr. Darío Contreras", true },
                    { new Guid("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), "Specialized", new Guid("e5f67890-3456-4567-5678-90abcdef1234"), "Centro Médico Cibao", false },
                    { new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), "General", new Guid("d4e5f678-2345-3456-4567-890abcdef123"), "Hospital General y de Especialidades Nuestra Señora de la Altagracia (HGENSA)", true },
                    { new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), "General", new Guid("c3d4e5f6-1234-5678-9abc-def123456789"), "Clínica Unión Médica del Norte", true }
                });

            migrationBuilder.InsertData(
                table: "HealthInsurances",
                columns: new[] { "Id", "CoverageLevel", "InsuranceCompany", "InsuranceName", "PolicyType" },
                values: new object[,]
                {
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), "High", "VivaSalud", "Plan Familiar Salud", "Family" },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), "Low", "SaludCo", "Seguro Salud Total", "Individual" }
                });

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "Id", "Description", "IcdCode", "Title" },
                values: new object[,]
                {
                    { new Guid("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"), "Alteraciones del color de la piel debidas a la ingestión o la inyección de un medicamento. Pueden obedecer a diferentes mecanismos, como el color del propio medicamento, una alteración de la melanización cutánea o el depósito de pigmentos por productos de degradación del fármaco.", "EH70", "Alteraciones pigmentarias de la piel por medicamentos" },
                    { new Guid("7791a6c3-b96b-4fd2-8777-1fabc70a3911"), "", "9C21", "Endoftalmitis" },
                    { new Guid("99c26293-7562-4d6a-9aa1-260bedb215a6"), "Afección causada por un exceso de líquido en los pulmones. Este líquido se acumula en los numerosos sacos alveolares de los pulmones, lo cual dificulta la respiración.\r\n", "CB01", "Edema pulmonar" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "Status", "TestCode", "TestName" },
                values: new object[,]
                {
                    { new Guid("0c8b53f4-6962-4f89-807e-737900741e13"), true, "R005", "Radiografía de tórax" },
                    { new Guid("2b5d9a1c-4e7f-3a8c-6b9d-5f2a3e4b1f7a"), true, "P002", "Perfil Lipídico" },
                    { new Guid("3c5d6e7f-89ab-4cde-bdef-3456789abcd0"), true, "M004", "Examen microbiológico ocular" },
                    { new Guid("9d2a5e4c-8b3f-4a7d-9c5b-3f2e1b6a7d9c"), true, "H001", "Hemograma Completo" },
                    { new Guid("ab3f3482-973d-4912-8848-f82bbb107792"), true, "B003", "Biopsia de piel" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "EntityId", "EntityType", "Latitude", "Longitude", "MunicipalityId", "PostalCode", "ProvinceId", "RegionId", "Status" },
                values: new object[,]
                {
                    { new Guid("a1c1b2c3-d4e5-678f-1234-56789abcdef0"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), "HealthCenter", 18.4861m, -69.8791m, new Guid("34567890-3456-3456-3456-34567890abcd"), "10101", new Guid("23456789-2345-2345-2345-234567890abc"), new Guid("12345678-1234-1234-1234-1234567890ab"), false },
                    { new Guid("b2c3d4e5-f678-1234-5678-abcdef123456"), new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), "HealthCenter", 19.4517m, -70.1626m, new Guid("65432109-6543-6543-6543-abcdef345678"), "10202", new Guid("76543210-5432-5432-5432-abcdef234567"), new Guid("87654321-4321-4321-4321-abcdef123456"), false },
                    { new Guid("c3d4e5f6-1234-5678-9abc-def123456789"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), "HealthCenter", 19.4667m, -71.2992m, new Guid("67890123-4567-5678-6789-abcdef890123"), "10303", new Guid("56789012-3456-4567-5678-abcdef789012"), new Guid("45678901-2345-3456-4567-abcdef678901"), false },
                    { new Guid("d4e5f678-2345-3456-4567-890abcdef123"), new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), "HealthCenter", 18.5398m, -69.9112m, new Guid("87654321-0987-6543-2109-fedcba765432"), "10404", new Guid("98765432-1098-7654-3210-fedcba876543"), new Guid("09876543-2109-8765-4321-fedcba987654"), false },
                    { new Guid("e5f67890-3456-4567-5678-90abcdef1234"), new Guid("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), "HealthCenter", 19.1873m, -70.6872m, new Guid("54321098-7654-3210-9876-fedcba432109"), "10505", new Guid("65432109-8765-4321-0987-fedcba543210"), new Guid("76543210-9876-5432-1098-fedcba654321"), false }
                });

            migrationBuilder.InsertData(
                table: "MedicalSpecialties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a6b7c8d9-e0f1-2345-6789-abcdef012345"), "Se centra en el diagnóstico, tratamiento y prevención de trastornos mentales, emocionales y del comportamiento.", "Psiquiatría" },
                    { new Guid("b1c2d3e4-f5a6-6789-0123-abcdef456789"), "Dedicada a la atención médica de bebés, niños y adolescentes.", "Pediatría" },
                    { new Guid("b7c8d9e0-f1a2-3456-7890-abcdef123456"), "Se especializa en el cuidado médico y quirúrgico de los ojos y la visión.", "Oftalmología" },
                    { new Guid("c2d3e4f5-a6b7-8901-2345-abcdef678901"), "Se especializa en el diagnóstico y tratamiento del sistema musculoesquelético.", "Ortopedia" },
                    { new Guid("c8d9e0f1-a2b3-4567-8901-abcdef234567"), "Dedicada al diagnóstico y tratamiento de trastornos relacionados con las hormonas.", "Endocrinología" },
                    { new Guid("d3e4f5a6-b7c8-9012-3456-abcdef789012"), "Se centra en el diagnóstico y tratamiento de afecciones de la piel.", "Dermatología" },
                    { new Guid("d9e0f1a2-b3c4-5678-9012-abcdef345678"), "Se centra en el diagnóstico y tratamiento de los trastornos del sistema respiratorio.", "Neumología" },
                    { new Guid("e0f1a2b3-c4d5-6789-0123-abcdef456789"), "Se especializa en el diagnóstico y tratamiento del aparato digestivo.", "Gastroenterología" },
                    { new Guid("e4f5a6b7-c8d9-0123-4567-abcdef890123"), "Especializado en el diagnóstico y tratamiento del cáncer.", "Oncología" },
                    { new Guid("f5a6b7c8-d9e0-1234-5678-abcdef901234"), "Dedicada a la salud y enfermedades del aparato reproductor femenino.", "Ginecología" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "ActiveIngredient", "Concentration", "Contraindications", "DosageForm", "DrugInteractions", "ImageUrl", "Indications", "Name", "NationalCode", "Precautions", "Presentation", "RouteOfAdministration", "SideEffects", "Status", "UnitOfMeasurement" },
                values: new object[,]
                {
                    { new Guid("3d69e605-c5e4-42f0-9f00-18f3a12f54ed"), "Glimepirida", 2m, "Insuficiencia renal severa, cetoacidosis diabética.", "Tablet", "Interacción con otros medicamentos antidiabéticos.", "http://example.com/glimepirida.jpg", "Tratamiento de la diabetes tipo 2.", "Glimepirida", "G2", "Uso con precaución en personas con antecedentes de hipoglucemia.", "Caja con 30 tabletas de 2 mg.", "Oral", "Hipoglucemia, aumento de peso, mareos.", true, "mg" },
                    { new Guid("4b2c6894-cc7d-4565-bb18-aba013826de7"), "Sertralina", 50m, "Hipersensibilidad a la sertralina, embarazo.", "Tablet", "Puede interactuar con inhibidores de la monoaminooxidasa (IMAO).", "http://example.com/sertralina.jpg", "Tratamiento de la depresión y trastornos de ansiedad.", "Sertralina", "S50", "Uso con precaución en personas con antecedentes de trastornos convulsivos.", "Caja con 30 tabletas de 50 mg.", "Oral", "Náuseas, insomnio, mareos.", true, "mg" },
                    { new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), "Metformina", 500m, "Insuficiencia renal severa, cetoacidosis diabética.", "Tablet", "Mayor riesgo de acidosis láctica con alcohol.", "http://example.com/metformina.jpg", "Tratamiento de la diabetes tipo 2.", "Metformina", "M500", "Controlar función renal periódicamente.", "Caja con 30 tabletas de 500 mg.", "Oral", "Náuseas, vómitos, diarrea, dolor abdominal.", true, "mg" },
                    { new Guid("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"), "Ibuprofeno", 200m, "Úlceras gástricas, insuficiencia renal.", "Tablet", "Puede aumentar el riesgo de sangrado con anticoagulantes.", "http://example.com/ibuprofeno.jpg", "Alivio de dolor leve a moderado y fiebre.", "Ibuprofeno", "I200", "Administrar con alimentos para evitar malestar estomacal.", "Caja con 20 tabletas de 200 mg.", "Oral", "Malestar estomacal, dolor de cabeza, mareos.", true, "mg" },
                    { new Guid("c3f4a6b7-8d1e-4b9c-2e7a-1c5b3d6f9e7a"), "Ibuprofeno", 400m, "Úlcera péptica activa, insuficiencia renal severa.", "Tablet", "Disminuye el efecto de los antihipertensivos.", "http://example.com/ibuprofeno.jpg", "Alivio de dolor leve a moderado, fiebre.", "Ibuprofeno", "I400", "Usar con precaución en pacientes con antecedentes de sangrado gastrointestinal.", "Caja con 20 tabletas de 400 mg.", "Oral", "Náuseas, dispepsia, riesgo de sangrado gastrointestinal.", true, "mg" },
                    { new Guid("d7e1c5b3-8f4a-4b6c-9f9e-2a7a1d6f8e9a"), "Paracetamol", 120m, "Insuficiencia hepática severa.", "Syrup", "Aumenta el riesgo de toxicidad hepática con alcohol.", "http://example.com/paracetamol.jpg", "Alivio de fiebre y dolor leve a moderado.", "Paracetamol", "P120", "Evitar dosis superiores a las recomendadas.", "Frasco de 120 mL con 120 mg/5mL.", "Oral", "Raro: reacciones alérgicas, daño hepático en sobredosis.", true, "mg/5mL" },
                    { new Guid("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"), "Losartán", 50m, "Embarazo, lactancia, hipersensibilidad al losartán.", "Tablet", "Interacción con diuréticos y otros antihipertensivos.", "http://example.com/losartan.jpg", "Tratamiento para hipertensión y insuficiencia renal.", "Losartán", "L50", "Controlar la función renal durante el tratamiento.", "Caja con 30 tabletas de 50 mg.", "Oral", "Mareo, dolor de cabeza, hiperkalemia.", true, "mg" },
                    { new Guid("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"), "Atorvastatina", 20m, "Hipersensibilidad al principio activo, enfermedad hepática activa.", "Tablet", "Mayor riesgo de miopatía con gemfibrozil o ciclosporina.", "http://example.com/atorvastatina.jpg", "Reducción de niveles elevados de colesterol y triglicéridos.", "Atorvastatina", "A020", "Controlar función hepática periódicamente.", "Caja con 30 tabletas de 20 mg.", "Oral", "Dolor muscular, elevación de enzimas hepáticas.", true, "mg" },
                    { new Guid("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"), "Naproxeno", 250m, "Úlceras gástricas, insuficiencia renal.", "Tablet", "Aumenta el riesgo de sangrado con anticoagulantes.", "http://example.com/naproxeno.jpg", "Alivio de dolor articular e inflamación.", "Naproxeno", "N250", "Tomar con alimentos para reducir riesgo de irritación estomacal.", "Caja con 30 tabletas de 250 mg.", "Oral", "Dolor estomacal, mareos, somnolencia.", true, "mg" },
                    { new Guid("f6b9a1c5-2e7a-3d6f-8d1e-4b3c7f9e7a1c"), "Amoxicilina", 500m, "Hipersensibilidad a penicilinas.", "Capsule", "Disminuye la eficacia de anticonceptivos orales.", "http://example.com/amoxicilina.jpg", "Tratamiento de infecciones bacterianas como faringitis y otitis media.", "Amoxicilina", "A500", "Usar con precaución en pacientes con antecedentes de reacciones alérgicas.", "Caja con 12 cápsulas de 500 mg.", "Oral", "Erupciones cutáneas, diarrea, náuseas.", true, "mg" }
                });

            migrationBuilder.InsertData(
                table: "RiskFactors",
                columns: new[] { "Id", "Description", "IcdCode", "Title" },
                values: new object[,]
                {
                    { new Guid("a34f2c12-d4b6-42e9-8f7a-9012c3e4f567"), "Tabaquismo activo", "I250", "Tabaquismo" },
                    { new Guid("b78f3e45-c5d6-47e1-a9f8-3456d7e8f901"), "Obesidad", "E669", "Obesidad" },
                    { new Guid("c98f4e56-d7f8-489a-b9e1-4567e8f9a012"), "Consumo de drogas", "F102", "Drogadicción" },
                    { new Guid("d12f5e67-e9f0-4a9b-c8f2-5678f9a0b123"), "Cirrosis hepática", "K746", "Cirrosis Hepática" },
                    { new Guid("e23f6e78-f1f2-4b0c-d9f3-6789a0b1c234"), "Sedentarismo", "Z720", "Sedentarismo" },
                    { new Guid("f45f7e89-a1c2-4b5d-bcde-67890a1b2345"), "Uso prolongado de lentes de contacto", "H522", "Uso prolongado de lentes de contacto" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageURL", "Name" },
                values: new object[,]
                {
                    { new Guid("2280068e-12b0-44f8-a07a-bc0f8cee2d80"), "Servicio de atención a emergencias médicas", "https://example.com/images/emergencies.jpg", "Emergencias" },
                    { new Guid("31a45603-22c1-4694-8bae-f1321999b132"), "Servicio de imágenes médicas y radiografías", "https://example.com/images/radiology.jpg", "Radiología" },
                    { new Guid("609da5c7-b6c3-462e-af5e-c39ad3874cd7"), "Servicio de consulta médica general", "https://example.com/images/general-consultation.jpg", "Consulta General" },
                    { new Guid("967b98b0-4718-4da3-852f-e38b701d49dd"), "Servicio de análisis de laboratorio", "https://example.com/images/laboratory.jpg", "Laboratorio Clínico" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "CardId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a5b"), 0, new DateTime(1995, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0587654321", "271097ca-99ca-4327-bac5-a11f18023162", "registrator@sedis.com", true, "Gilthong Emmanuel", ".", "Palin Garcia", false, null, null, null, "AQAAAAIAAYagAAAAEF06YcTZpmrC/Udx83sMcvYX4B80YpIwBhkEUxZp3mmoHUZwxeOpskr1cqBFRJmoTA==", "829-123-9312", true, "d39f04dc-b328-4de1-9a92-0f392d4470be", "M", false, false, "digitaregistrator" },
                    { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), 0, new DateTime(1995, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987634321", "bdc1701b-009c-4beb-b8f4-e6204215ae24", "assistantuser@sedis.com", true, "Ana", ".", "Martínez", false, null, null, null, "AQAAAAIAAYagAAAAELdfs4pxJXChkp+UJhzNx+zHrgKjTMDlo3wPQEyzoCSMZIdZNuX7xBX82Q25yVeo0g==", "829-123-9811", true, "1ff8c6e2-57a4-459c-b477-de69a507d2d7", "F", false, false, "assistantuser" },
                    { new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"), 0, new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1122334455", "1f7f14f8-87e7-4396-8904-e81ce974453b", "registrator.cdm@sedis.com", true, "Maria", ".", "Lopez", false, null, null, null, "AQAAAAIAAYagAAAAEA2Y9JSgp4YJuWjf3k4o9jp67hJPX/ctp+AWAgR+MdpAaVPsXPI6Rd+VQ0kWpQh2qw==", "809-987-6543", true, "df2c5466-1059-491c-b899-2ee8e6949433", "F", true, false, "registrator_cdm" },
                    { new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), 0, new DateTime(1985, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "3344556677", "1fca05f9-7045-4fea-9e0a-c42eeb443220", "registrator.union@sedis.com", true, "Carlos", ".", "Gonzalez", false, null, null, null, "AQAAAAIAAYagAAAAEK2naswixwJ1JHXVr+ekd3LHXqqYc8i8r9bg88O7EYHO2DnhQz0Ml3wUCAYI3Ouyyw==", "809-254-5678", true, "517bbd70-a78e-4c16-ad7d-917e0a646600", "M", true, false, "registrator_union" },
                    { new Guid("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901", "8d3762ee-51fa-4cdb-9578-dece9b877fae", "carlos@sedis.com", true, "Carlos", ".", "Perez", false, null, null, null, "AQAAAAIAAYagAAAAEJVz9+YZ5rqiNQtQQYappWHeb7eFh1E902ORBqM9rZoj8Ap4hSm1SZVcISOmnzkRmg==", "809-123-4567", true, "c7021e73-e609-4b17-bd94-e84a1539cac4", "M", true, false, "tech1user" },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), 0, new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608640", "8777171f-dcd9-4a9a-98f0-0fb53ab6e62b", "isaac@sedis.com", true, "Isaac Alexander", ".", "Polonio", false, null, null, null, "AQAAAAIAAYagAAAAEH9wb5KFzfarTz8UzEJKTMPPCBZm+f6EIjGnfvPRKgzhEcgSK30LybLoyVu11hXhaQ==", "829-123-9812", true, "18bdbbb5-d5f8-44aa-91f5-77ad2b547d78", "M", true, false, "doctor" },
                    { new Guid("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13579246801", "1cbf2ed1-9488-4824-afec-c9aa4dc336ea", "luis@sedis.com", true, "Luis", ".", "Gomez", false, null, null, null, "AQAAAAIAAYagAAAAEIS6wo6LAQDonN55N1KHIW9vRAiiP9RzuExrHJirNJp14d8h0QBnvrn4BR+8hZTXHw==", "809-345-6789", true, "77e4ba74-d070-48ff-a778-5c64a9625f16", "M", true, false, "tech3user" },
                    { new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), 0, new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "4455667788", "8f396860-fe87-4076-9801-e27bd5462fff", "registrator.altagracia@sedis.com", true, "Ana", ".", "Martinez", false, null, null, null, "AQAAAAIAAYagAAAAENVwwMaMzqIdyaulo5pzJkMO4fBgib8p3pdfKdOk51BDbzZMfy+Ok58ZlBiyMar1wA==", "809-876-5432", true, "798a8dc0-6814-44b8-a4ad-0264010df466", "F", true, false, "registrator_altagracia" },
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608641", "8ad428d9-c293-4ade-8ff2-8836b6a9d6ca", "patient@email.com", true, "Mark", ".", "Abreu", false, null, null, null, "AQAAAAIAAYagAAAAECBfogixIwKVpbWxiWL/bPLBFfRJdfSRi6vIi0uqnMmXEU7wOCbY0XYIYvXTBNvlrw==", "829-163-9811", true, "36702246-4072-4b3c-96de-64a677ad6eee", "M", true, false, "patient" },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608648", "8ed64f48-a5e9-4ac9-b4bb-b2250fa73d58", "alicepatient@sedis.com", true, "Alice", ".", "Smith", false, null, null, null, "AQAAAAIAAYagAAAAEMrGXgpyfWmcDTHoMRUw578JimJeCOK6ragd9HLdaQeTgLIos6ydDhgBiHr7AxY7QQ==", "829-128-9811", true, "298250b8-d818-49bd-a51c-edba0ae801eb", "F", true, false, "patient2" },
                    { new Guid("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "98765432101", "ca13ab66-7727-4d41-add0-b9d4ceb55faf", "maria@sedis.com", true, "Maria", ".", "Lopez", false, null, null, null, "AQAAAAIAAYagAAAAEGbwCi0+yTT9wB54vdPpufkvFKxd445TO/6hPllmR/ivUE+qHk4hmfFj3P4CCtGZJg==", "809-234-4678", true, "32a8b6bc-aaaf-4b62-b423-7ee5ec399df9", "F", true, false, "tech2user" },
                    { new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), 0, new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "5566778899", "f3cac17a-20f0-4d32-877f-9772b6275024", "registrator.cibao@sedis.com", true, "Luis", ".", "Santos", false, null, null, null, "AQAAAAIAAYagAAAAEInPk7Rxrw8KTCoDT+i3WypQWhQKzs1FHYqulsi6BCMVEZNZ02/RmTUavmmkydj7mA==", "809-321-9876", true, "fa3fae20-8152-446a-8f9b-49f3548982a1", "M", false, false, "registrator_cibao" },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), 0, new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "663d9b2c-47d1-4b50-8984-696e736adadf", "layladoc@sedis.com", true, "Layla", ".", "Vargas", false, null, null, null, "AQAAAAIAAYagAAAAEL40Ao8xuoww/sXYXS+bRV7YglkjA5Z/zYe2ZOD+s4j/5Y7wtEiAmFda9sFX4Sgb1g==", "829-123-9231", true, "217b6329-d07e-4eba-a35f-5c85758afdf2", "F", false, false, "doctor2" },
                    { new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40323958764", "657eeb87-07bd-4118-9f1e-046e1f6d7cb5", "geremy@sedis.com", true, "Geremy", ".", "Ferrán", false, null, null, null, "AQAAAAIAAYagAAAAEHwRaLnOCmIl5a18dZj9TODJ8tWOeTl/kH02jZ/7ajYdpnhc4q5f6BLdNgyX3zlS6w==", "829-143-9811", true, "1f9bae09-4c2b-483f-a766-36a4e665d37e", "M", true, false, "adminuser" },
                    { new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608647", "8ebe475f-b89e-44c5-b256-f27f4022bdef", "brahiam@sedis.com", true, "Brahiam", ".", "Montero", false, null, null, null, "AQAAAAIAAYagAAAAEAc5qLFWSOyUG9Kj2ouccscbWCGKDLQAB368v15cfCcZm1IeHMsjOj1Bfh6lYhkakQ==", "809-962-2004", true, "ad4822ec-c1b1-4ef3-ab29-22d13154b3d6", "M", true, false, "adminuser" }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "Id", "Doses", "Laboratory", "Name" },
                values: new object[,]
                {
                    { new Guid("04561950-934c-47d9-a4df-55daa2143135"), 2, "Merck", "Vacuna contra el sarampión" },
                    { new Guid("308c146a-7b3e-4426-b394-971aad7e50bb"), 1, "GlaxoSmithKline", "Vacuna contra el tétanos" },
                    { new Guid("9c7bed88-e92c-459d-8a50-2fd9041c2c26"), 3, "Sanofi Pasteur", "Vacuna contra la hepatitis B" },
                    { new Guid("d8d4c92b-a7d9-4205-8524-829ef5ca97d7"), 2, "Merck", "Vacuna contra el VPH" },
                    { new Guid("ff079100-01b3-4902-86b0-64083d72c6fe"), 2, "Pfizer", "Vacuna contra la varicela" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "HealthCenterId", "Status" },
                values: new object[,]
                {
                    { new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), true },
                    { new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), true }
                });

            migrationBuilder.InsertData(
                table: "Assistants",
                columns: new[] { "Id", "HealthCenterId", "Status" },
                values: new object[] { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), false });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CurrentlyWorkingHealthCenterId", "LicenseNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), "LIC12345678", false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), "LIC98765432", false }
                });

            migrationBuilder.InsertData(
                table: "LabTechs",
                columns: new[] { "Id", "HealthCenterId", "Status" },
                values: new object[,]
                {
                    { new Guid("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"), new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), true },
                    { new Guid("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), true },
                    { new Guid("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"), new Guid("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), true }
                });

            migrationBuilder.InsertData(
                table: "MedicationCoverages",
                columns: new[] { "HealthInsuranceId", "MedicationId", "CoinsurancePercentage", "CopayAmount", "PriorAuthorizationRequired", "Status" },
                values: new object[,]
                {
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), 80m, 50m, true, true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("c3f4a6b7-8d1e-4b9c-2e7a-1c5b3d6f9e7a"), 40m, 20m, false, true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("d7e1c5b3-8f4a-4b6c-9f9e-2a7a1d6f8e9a"), 50m, 10m, false, true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"), 90m, 70m, false, true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("f6b9a1c5-2e7a-3d6f-8d1e-4b3c7f9e7a1c"), 60m, 30m, true, true }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType", "BloodTypeLabResultURl", "EmergencyContactName", "EmergencyContactPhone", "Height", "PrimaryCarePhysicianId", "Status", "Weight" },
                values: new object[,]
                {
                    { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), "O+", "http://example.com/lab-results/ana-martinez", "John Martinez", "829-123-9811", 165.0m, null, false, 60.0m },
                    { new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"), "AB+", "http://example.com/lab-results/maria-lopez", "Ana Lopez", "809-987-6543", 170.0m, null, false, 65.0m },
                    { new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), "O-", "http://example.com/lab-results/carlos-gonzalez", "Luis Gonzalez", "809-234-5678", 178.0m, null, false, 80.0m },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "A+", "http://example.com/lab-results/isaac-polonio", "Alex Polonio", "829-123-9812", 180.0m, null, false, 85.0m },
                    { new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), "A-", "http://example.com/lab-results/ana-martinez", "John Martinez", "809-876-5432", 165.0m, null, false, 60.0m },
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "A+", "http://example.com/lab-results/mark-abreu", "Maria Abreu", "809-123-4567", 172.5m, null, false, 70.0m },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "O-", "http://example.com/lab-results/alice-smith", "John Smith", "809-987-6543", 160.3m, null, false, 55.0m },
                    { new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), "B+", "http://example.com/lab-results/luis-santos", "Carlos Santos", "809-321-9876", 172.0m, null, false, 78.0m },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), "B-", "http://example.com/lab-results/layla-vargas", "Sophia Vargas", "829-123-9231", 162.0m, null, false, 58.0m },
                    { new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), "B+", "http://example.com/lab-results/geremy-ferran", "Ana Ferrán", "829-123-1111", 175.8m, null, false, 78.5m },
                    { new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), "AB+", "http://example.com/lab-results/brahiam-montero", "Luis Montero", "829-222-3333", 182.0m, null, false, 85.2m }
                });

            migrationBuilder.InsertData(
                table: "Registrators",
                columns: new[] { "Id", "HealthCenterId", "Status" },
                values: new object[,]
                {
                    { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a5b"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), false },
                    { new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"), new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), false },
                    { new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), false },
                    { new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), false },
                    { new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), new Guid("8b971b1f-3f6e-46a8-9b27-805af468bbb4"), false }
                });

            migrationBuilder.InsertData(
                table: "DoctorMedicalSpecialties",
                columns: new[] { "DoctorId", "MedicalSpecialtyId", "Status" },
                values: new object[,]
                {
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("a6b7c8d9-e0f1-2345-6789-abcdef012345"), false },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("b1c2d3e4-f5a6-6789-0123-abcdef456789"), false },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("b7c8d9e0-f1a2-3456-7890-abcdef123456"), false },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("c2d3e4f5-a6b7-8901-2345-abcdef678901"), false },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("c8d9e0f1-a2b3-4567-8901-abcdef234567"), false },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("d3e4f5a6-b7c8-9012-3456-abcdef789012"), false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("d3e4f5a6-b7c8-9012-3456-abcdef789012"), false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("d9e0f1a2-b3c4-5678-9012-abcdef345678"), false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("e0f1a2b3-c4d5-6789-0123-abcdef456789"), false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("e4f5a6b7-c8d9-0123-4567-abcdef890123"), false },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("f5a6b7c8-d9e0-1234-5678-abcdef901234"), false }
                });

            migrationBuilder.InsertData(
                table: "FamilyHistories",
                columns: new[] { "Id", "Condition", "PatientId", "Relationship", "RelativeId", "Status" },
                values: new object[,]
                {
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), "", new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "Mother", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), true },
                    { new Guid("5c52a9d3-6ee2-496e-a922-139de857d9d4"), "", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "Son", new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), false },
                    { new Guid("d7446d5f-93b0-4c94-8e10-ba5567f50b7b"), "", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "Aunt", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), false }
                });

            migrationBuilder.InsertData(
                table: "MedicalConsultations",
                columns: new[] { "Id", "AppointmentId", "CreatedDate", "CurrentHistory", "DoctorId", "LastModifiedDate", "PatientId", "PhysicalExamination", "ReasonForVisit", "Status" },
                values: new object[,]
                {
                    { new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), new Guid("0c8b4a52-f34c-4a7f-90d2-3c84d8c1d6b1"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7898), "Patient reports mild discomfort and fatigue in the eyes after working on a computer for extended periods.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7898), new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), "Visual acuity slightly reduced in low light. Suggested blue light filtering glasses and breaks during screen usage.", "Eye strain during extended screen time.", "Pending" },
                    { new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), new Guid("12345678-90ab-cdef-1234-567890abcdef"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7909), "Paciente reporta episodios de disnea y fatiga tras actividades leves.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7910), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "Estertores crepitantes en ambos campos pulmonares.", "Dificultades respiratorias persistentes.", "Completed" },
                    { new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("792b5eb8-35dc-4e11-8d36-bb4b0344f582"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7885), "Patient reports persistent issues with vision clarity and difficulty reading fine print over the past three months.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7891), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "Observed squinting during visual acuity tests. Referral to ophthalmology recommended.", "Difficulty reading and focusing on objects.", "Completed" },
                    { new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), new Guid("09876543-21dc-ba98-7654-3210fedcba98"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7917), "Paciente refiere inicio agudo de dolor ocular intenso, acompañado de visión borrosa.", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7917), new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), "Inflamación severa en cámara anterior, opacidades vítreas observadas.", "Dolor ocular y disminución de visión.", "Completed" },
                    { new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("d6c8a3b4-a72f-45df-9143-17c8b3d2fdf0"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7904), "Patient reports difficulty hearing in noisy environments. Speech development has been slower than expected.", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 11, 30, 1, 19, 49, 65, DateTimeKind.Utc).AddTicks(7904), new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), "Hearing tests confirm moderate hearing loss. Advised evaluation for hearing aids and speech therapy.", "Hearing difficulties and speech development concerns.", "Ongoing" }
                });

            migrationBuilder.InsertData(
                table: "PatientHealthInsurances",
                columns: new[] { "HealthInsuranceId", "PatientId", "PolicyNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), "P3456789012", true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"), "P6789012345", true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), "P7890123456", true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "P4567890123", true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), "P8901234567", true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "P0123456789", true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "P0987654321", true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), "P9012345678", true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), "P5678901234", true },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), "P1234567890", true },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), "P2345678901", true }
                });

            migrationBuilder.InsertData(
                table: "PatientVaccines",
                columns: new[] { "PatientId", "VaccineId", "AppliedDoses", "LastApplicationDate", "MedicalConsultationId", "Status" },
                values: new object[,]
                {
                    { new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), new Guid("9c7bed88-e92c-459d-8a50-2fd9041c2c26"), 3, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true },
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new Guid("308c146a-7b3e-4426-b394-971aad7e50bb"), 2, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("ff079100-01b3-4902-86b0-64083d72c6fe"), 2, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true },
                    { new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), new Guid("04561950-934c-47d9-a4df-55daa2143135"), 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true },
                    { new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new Guid("d8d4c92b-a7d9-4205-8524-829ef5ca97d7"), 2, new DateTime(2021, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "ConsultationRoom", "DoctorId", "HealthCenterId", "MedicalConsultationId", "PatientId", "Status" },
                values: new object[,]
                {
                    { new Guid("0c8b4a52-f34c-4a7f-90d2-3c84d8c1d6b1"), new DateTime(2023, 11, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Room 102", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), "Pending" },
                    { new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Room 101", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "Completed" },
                    { new Guid("d6c8a3b4-a72f-45df-9143-17c8b3d2fdf0"), new DateTime(2023, 11, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Room 103", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), "Ongoing" }
                });

            migrationBuilder.InsertData(
                table: "PatientAllergies",
                columns: new[] { "AllergyId", "PatientId", "Allergen", "AllergicReaction", "Description", "DiagnosisDate", "MedicalConsultationId", "Status" },
                values: new object[,]
                {
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), "Polen", "Congestión nasal y estornudos", "Reacción alérgica leve al polen durante la primavera.", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), true },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"), "Lácteos", "Dolor abdominal y náuseas", "Reacción leve a productos lácteos.", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), true },
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), "Polen de flores", "Picazón en los ojos y congestión nasal", "Reacción alérgica durante la primavera.", new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), true },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "Maní", "Dificultad para respirar y urticaria", "Reacción severa a la exposición al maní.", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), true },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), "Gluten", "Diarrea y fatiga", "Reacción leve a alimentos con gluten.", new DateTime(2020, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), true },
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), "Ácaros del polvo", "Estornudos frecuentes y congestión nasal", "Reacción moderada al polvo en casa.", new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), true }
                });

            migrationBuilder.InsertData(
                table: "PatientDiscapacities",
                columns: new[] { "DiscapacityId", "PatientId", "Description", "DiagnosisDate", "MedicalConsultationId", "Severity", "Status" },
                values: new object[,]
                {
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "El paciente presenta dificultades visuales complejas.", new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), "Severa", true },
                    { new Guid("5c52a9d3-6ee2-496e-a922-139de857d9d4"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "El paciente presenta pérdida auditiva moderada desde el nacimiento.", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), "Moderada", true },
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), "El paciente requiere soporte para tareas visuales prolongadas.", new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), "Leve", true }
                });

            migrationBuilder.InsertData(
                table: "PatientIllnesses",
                columns: new[] { "IllnessId", "PatientId", "DiagnosisDate", "DischargeDate", "DocumentURL", "MedicalConsultationId", "Notes", "Status" },
                values: new object[,]
                {
                    { new Guid("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://example.com/document/skin-pigmentation.pdf", new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), "El paciente está bajo monitoreo y tratamiento tópico para los cambios en la pigmentación de la piel.", "Activa" },
                    { new Guid("99c26293-7562-4d6a-9aa1-260bedb215a6"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://example.com/document/pulmonary-edema.pdf", new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), "Paciente respondió favorablemente a la terapia diurética.", "En remisión" },
                    { new Guid("7791a6c3-b96b-4fd2-8777-1fabc70a3911"), new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://example.com/document/endoftalmitis-diagnosis.pdf", new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), "Tratamiento antibiótico y seguimiento con oftalmología especializado.", "Activa" }
                });

            migrationBuilder.InsertData(
                table: "PatientLabTestPrescriptions",
                columns: new[] { "Id", "DoctorId", "InvalidationDate", "LabTechId", "LabTestId", "MedicalConsultationId", "PatientId", "PerformedDate", "ResultUrl", "SolicitedDate", "Status" },
                values: new object[,]
                {
                    { new Guid("34a6c639-f539-4eb4-b19a-82a8c0cc2a49"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), null, new Guid("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"), new Guid("3c5d6e7f-89ab-4cde-bdef-3456789abcd0"), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/results-endoftalmitis.pdf", null, "Completed" },
                    { new Guid("96fdb47b-e0ad-48c6-868d-0451f4d297b2"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), null, new Guid("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"), new Guid("0c8b53f4-6962-4f89-807e-737900741e13"), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/results-pulmonary-edema.pdf", null, "Pending" },
                    { new Guid("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), null, new Guid("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"), new Guid("ab3f3482-973d-4912-8848-f82bbb107792"), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/results-skin.pdf", null, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "PatientMedicationPrescription",
                columns: new[] { "Id", "DoctorId", "EndDate", "MedicalConsultationId", "MedicationId", "Notes", "PatientId", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("42ad98b9-5bce-43bc-bd62-0eb4ed744c38"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), new Guid("4b2c6894-cc7d-4565-bb18-aba013826de7"), "Tratamiento para depresión y ansiedad.", new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("591b3031-316a-4bbb-8ad6-d399e6953b96"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), new Guid("3d69e605-c5e4-42f0-9f00-18f3a12f54ed"), "Control de glucosa en paciente con diabetes tipo 2.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("72125267-6107-4757-8b69-0b12e12cf125"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"), "Tratamiento para hipertensión.", new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("916e9144-b970-45f8-a253-b15d28c647b8"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), "Iniciar tratamiento para controlar la glucosa.", new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("91be016e-e4cb-429f-a08d-2a694f5692e4"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"), "Medicamento para el dolor articular y la inflamación.", new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("bd403def-cac2-42ed-890d-aa59adf196e0"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), new Guid("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"), "Tratamiento para el dolor abdominal severo y fiebre.", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "PatientRiskFactors",
                columns: new[] { "PatientId", "RiskFactorId", "DiagnosisDate", "MedicalConsultationId", "Status" },
                values: new object[,]
                {
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new Guid("c98f4e56-d7f8-489a-b9e1-4567e8f9a012"), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), "Activo" },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("a34f2c12-d4b6-42e9-8f7a-9012c3e4f567"), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), "Activo" },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("b78f3e45-c5d6-47e1-a9f8-3456d7e8f901"), new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), "En tratamiento" },
                    { new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new Guid("f45f7e89-a1c2-4b5d-bcde-67890a1b2345"), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), "Activo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_HealthCenterId",
                table: "Admins",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Id",
                table: "Admins",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HealthCenterId",
                table: "Appointments",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicalConsultationId",
                table: "Appointments",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_HealthCenterId",
                table: "Assistants",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_Id",
                table: "Assistants",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties",
                column: "MedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CurrentlyWorkingHealthCenterId",
                table: "Doctors",
                column: "CurrentlyWorkingHealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Id",
                table: "Doctors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistories_PatientId",
                table: "FamilyHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistories_RelativeId",
                table: "FamilyHistories",
                column: "RelativeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenterServices_ServiceId",
                table: "HealthCenterServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechs_HealthCenterId",
                table: "LabTechs",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechs_Id",
                table: "LabTechs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultations_DoctorId",
                table: "MedicalConsultations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultations_PatientId",
                table: "MedicalConsultations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_HealthInsuranceId",
                table: "MedicationCoverages",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_AllergyId",
                table: "PatientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_MedicalConsultationId",
                table: "PatientAllergies",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscapacities_DiscapacityId",
                table: "PatientDiscapacities",
                column: "DiscapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscapacities_MedicalConsultationId",
                table: "PatientDiscapacities",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHealthInsurances_HealthInsuranceId",
                table: "PatientHealthInsurances",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_MedicalConsultationId",
                table: "PatientIllnesses",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTestPrescriptions_DoctorId",
                table: "PatientLabTestPrescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTestPrescriptions_LabTechId",
                table: "PatientLabTestPrescriptions",
                column: "LabTechId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTestPrescriptions_LabTestId",
                table: "PatientLabTestPrescriptions",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTestPrescriptions_MedicalConsultationId",
                table: "PatientLabTestPrescriptions",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTestPrescriptions_PatientId",
                table: "PatientLabTestPrescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationPrescription_DoctorId",
                table: "PatientMedicationPrescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationPrescription_MedicalConsultationId",
                table: "PatientMedicationPrescription",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationPrescription_MedicationId",
                table: "PatientMedicationPrescription",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationPrescription_PatientId",
                table: "PatientMedicationPrescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRiskFactors_MedicalConsultationId",
                table: "PatientRiskFactors",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRiskFactors_RiskFactorId",
                table: "PatientRiskFactors",
                column: "RiskFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Id",
                table: "Patients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PrimaryCarePhysicianId",
                table: "Patients",
                column: "PrimaryCarePhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccines_MedicalConsultationId",
                table: "PatientVaccines",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccines_VaccineId",
                table: "PatientVaccines",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrators_HealthCenterId",
                table: "Registrators",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrators_Id",
                table: "Registrators",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CardId",
                table: "Users",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialties");

            migrationBuilder.DropTable(
                name: "FamilyHistories");

            migrationBuilder.DropTable(
                name: "HealthCenterServices");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MedicationCoverages");

            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.DropTable(
                name: "PatientDiscapacities");

            migrationBuilder.DropTable(
                name: "PatientHealthInsurances");

            migrationBuilder.DropTable(
                name: "PatientIllnesses");

            migrationBuilder.DropTable(
                name: "PatientLabTestPrescriptions");

            migrationBuilder.DropTable(
                name: "PatientMedicationPrescription");

            migrationBuilder.DropTable(
                name: "PatientRiskFactors");

            migrationBuilder.DropTable(
                name: "PatientVaccines");

            migrationBuilder.DropTable(
                name: "Registrators");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "MedicalSpecialties");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Discapacities");

            migrationBuilder.DropTable(
                name: "HealthInsurances");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "LabTechs");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "RiskFactors");

            migrationBuilder.DropTable(
                name: "MedicalConsultations");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
