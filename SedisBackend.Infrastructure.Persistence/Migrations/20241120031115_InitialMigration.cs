using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SedisBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Allergen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    HealthCenterCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyType = table.Column<int>(type: "int", nullable: false),
                    InsuranceCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverageLevel = table.Column<int>(type: "int", nullable: false)
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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosageForm = table.Column<int>(type: "int", nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concentration = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UnitOfMeasurement = table.Column<int>(type: "int", nullable: false),
                    RouteOfAdministration = table.Column<int>(type: "int", nullable: false),
                    Indications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraindications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugInteractions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentation = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    AssessmentLevel = table.Column<int>(type: "int", nullable: false)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doses = table.Column<int>(type: "int", nullable: false),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCenterServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenterServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCenterServices_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationCoverages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageStatus = table.Column<int>(type: "int", nullable: false),
                    CopayAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CoinsurancePercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PriorAuthorizationRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCoverages_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DoctorHealthCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExitHour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorHealthCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorHealthCenters_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorHealthCenters_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalSpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_MedicalSpecialities_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    ConsultationType = table.Column<int>(type: "int", nullable: false),
                    ConsultationRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClinicalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalExamination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalHistories_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "PatientAllergies",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_PatientDiscapacities_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientHealthInsurances",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHealthInsurances", x => new { x.PatientId, x.HealthInsuranceId });
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurances_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurances_Patients_PatientId",
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DischargeDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_PatientIllnesses_Patients_PatientId",
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRiskFactors", x => new { x.PatientId, x.RiskFactorId });
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedDoses = table.Column<int>(type: "int", nullable: false),
                    LastApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVaccines", x => new { x.PatientId, x.VaccineId });
                    table.ForeignKey(
                        name: "FK_PatientVaccines_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientVaccines_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicalHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtherPrescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_ClinicalHistories_ClinicalHistoryId",
                        column: x => x.ClinicalHistoryId,
                        principalTable: "ClinicalHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPrescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicalHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentPrescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentPrescriptions_ClinicalHistories_ClinicalHistoryId",
                        column: x => x.ClinicalHistoryId,
                        principalTable: "ClinicalHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationPrescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatmentStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TreatmentEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Allergen" },
                values: new object[,]
                {
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), "Peanuts" },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), "Penicillin" }
                });

            migrationBuilder.InsertData(
                table: "Discapacities",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), "Paraplejia que afecta las extremidades inferiores.", 1 },
                    { new Guid("5c52a9d3-6ee2-496e-a922-139de857d9d4"), "Pérdida total de la audición en ambos oídos.", 2 }
                });

            migrationBuilder.InsertData(
                table: "HealthCenters",
                columns: new[] { "Id", "HealthCenterCategory", "LocationId", "Name" },
                values: new object[,]
                {
                    { new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), "Especializado", new Guid("a6e819b6-3996-49d6-afc7-9b47206dcadc"), "North Health Center" },
                    { new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), "General", new Guid("945e98f3-80c7-4444-8d93-74b72efc78b1"), "Central Health Center" }
                });

            migrationBuilder.InsertData(
                table: "HealthInsurances",
                columns: new[] { "Id", "CoverageLevel", "InsuranceCompany", "InsuranceName", "PolicyType" },
                values: new object[,]
                {
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), 3, "VivaSalud", "Plan Familiar Salud", 1 },
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), 1, "SaludCo", "Seguro Salud Total", 0 }
                });

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "Id", "Code", "CodeType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"), "E10", 0, "Enfermedad crónica en la que el páncreas produce poca o ninguna insulina.", "Diabetes Mellitus Tipo 1" },
                    { new Guid("99c26293-7562-4d6a-9aa1-260bedb215a6"), "I10", 0, "Condición de presión arterial elevada sin causa identificable.", "Hipertensión esencial (primaria)" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "EntityId", "EntityType", "Latitude", "Longitude", "MunicipalityId", "PostalCode", "ProvinceId", "RegionId" },
                values: new object[,]
                {
                    { new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), new Guid("a6e819b6-3996-49d6-afc7-9b47206dcadc"), "HealthCenter", 18.4796m, -69.9010m, new Guid("65432109-6543-6543-6543-abcdef345678"), "10202", new Guid("76543210-5432-5432-5432-abcdef234567"), new Guid("87654321-4321-4321-4321-abcdef123456") },
                    { new Guid("945e98f3-80c7-4444-8d93-74b72efc78b1"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), "HealthCenter", 18.5067m, -69.8937m, new Guid("34567890-3456-3456-3456-34567890abcd"), "10101", new Guid("23456789-2345-2345-2345-234567890abc"), new Guid("12345678-1234-1234-1234-1234567890ab") }
                });

            migrationBuilder.InsertData(
                table: "MedicalSpecialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), "Focuses on the diagnosis and treatment of neurological disorders.", "Neurology" },
                    { new Guid("f1a2b3c4-d5e6-789f-0123-456789abcdef"), "Specializes in the treatment of heart conditions.", "Cardiology" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "ActiveIngredient", "Concentration", "Contraindications", "DosageForm", "DrugInteractions", "ImageUrl", "Indications", "Name", "NationalCode", "Precautions", "Presentation", "RouteOfAdministration", "SideEffects", "UnitOfMeasurement" },
                values: new object[,]
                {
                    { new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), "Metformina", 500m, "Insuficiencia renal", 2, "No usar con insulina", "http://example.com/image1.jpg", "Tratamiento de diabetes tipo 2", "Metformina", "M500", "Controlar niveles de glucosa", 11, 1, "Náuseas, vómitos", 9 },
                    { new Guid("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"), "Atorvastatina", 20m, "Enfermedad hepática", 2, "No usar con ciertos antibióticos", "http://example.com/image2.jpg", "Reducción de colesterol", "Atorvastatina", "A020", "Controlar niveles de lípidos", 4, 6, "Dolor muscular", 1 }
                });

            migrationBuilder.InsertData(
                table: "RiskFactors",
                columns: new[] { "Id", "AssessmentLevel", "Category", "Code", "CodeType", "Description" },
                values: new object[,]
                {
                    { new Guid("454e8d39-1363-41f4-a2d2-b99fde743fbf"), 3, 1, "L123", 0, "Consumo excesivo de alcohol" },
                    { new Guid("6522252f-0021-433b-8174-f4e0833f859a"), 2, 2, "G789", 0, "Historia familiar de diabetes" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "CardId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), 0, new DateTime(1995, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987634321", "2d0a1e3a-fd25-48ad-b8da-b764fe44c6b9", "assistantuser@email.com", true, "Ana", ".", false, "Martínez", false, null, null, null, "AQAAAAIAAYagAAAAEE7odLa86VrxJ3P2Itxb5ZgN3FN6V7xoY8jjd/4X10RMdQrlYq8fbg3+Lw1y7VXg7g==", "829-123-9811", true, "2d6b9d0b-9dc7-49fb-8f7a-689f36637214", "F", false, "assistantuser" },
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), 0, new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608640", "92a15b12-14a8-4560-bf92-6144377b7679", "doctoruser@email.com", true, "John", ".", true, "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEEDXHwLM5QVt3wg8Knokb9CVQPi3pK5EySySoaoXqg/zVBDrobz+gFGtaI2tCtHtLQ==", "829-123-9812", true, "38445e53-1b13-4047-9f57-5376eb8e5cda", "M", false, "doctoruser" },
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608641", "987234b4-5298-49a9-8d25-b1d7333a94d1", "patientuser@email.com", true, "John", ".", true, "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEJn4znV4gisTbUKK7MGViog0MriX/0TS1YA7nmj1furokan7Z8M+28oL0HZzfQc0LA==", "829-163-9811", true, "63907549-a8f6-41f9-9e07-55ad0e6b0c9f", "M", false, "patient" },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608648", "772673d1-f9b0-4fae-a51f-3d1d2fad0722", "patient2@email.com", true, "Alice", ".", true, "Smith", false, null, null, null, "AQAAAAIAAYagAAAAEDw6b6ftmPtavm1TvJrBa/D90zCclQK7a9LrIOVyb3N3oNuqGYlDWyDA1MhBQdES+A==", "829-128-9811", true, "06a081f4-54fb-489a-80c7-bfb932836239", "F", false, "patient2" },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), 0, new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "2fa33d12-cce3-4eea-8b21-6ba68375b523", "doctoruser2@email.com", true, "Jane", ".", false, "Smith", false, null, null, null, "AQAAAAIAAYagAAAAENaQfqotw6n44b94KAUMoJL0G4HI52GWDdXvt9u77YBFbV4U6v7jYqRb5JgFKb1Rug==", "829-123-9231", true, "6eef3b62-7621-4c37-bc30-e5c4fff76d92", "F", false, "doctoruser2" },
                    { new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40211608647", "2be47bea-7da8-4670-845f-681c1c4bccb9", "adminuser@email.com", true, "Brahiam", ".", true, "Montero", false, null, null, null, "AQAAAAIAAYagAAAAEEF/nzBU/YjJaVZvNqKXw9LlEAtljjh2/LF/5g5z2rYNaysBSK9ZMWyrstUQs18Vfw==", "829-143-9811", true, "d87e7cdf-6314-4dcf-9875-e394eda81f24", "M", false, "adminuser" }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "Id", "Disease", "Doses", "Laboratory", "Name" },
                values: new object[,]
                {
                    { new Guid("384e34fb-7d23-4123-a78e-13d7b0a91110"), "Influenza", 1, "Sanofi Pasteur", "Vacuna contra la gripe" },
                    { new Guid("c28e855d-2602-423f-a4d5-26954df029da"), "COVID-19", 2, "Pfizer-BioNTech", "Vacuna COVID-19" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "HealthCenterId", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), false, false });

            migrationBuilder.InsertData(
                table: "Assistants",
                columns: new[] { "Id", "HealthCenterId", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), false, false });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "IsActive", "IsDeleted", "LicenseNumber" },
                values: new object[,]
                {
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), false, false, "LIC12345678" },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), false, false, "LIC98765432" }
                });

            migrationBuilder.InsertData(
                table: "MedicationCoverages",
                columns: new[] { "Id", "CoinsurancePercentage", "CopayAmount", "CoverageStatus", "HealthInsuranceId", "MedicationId", "PriorAuthorizationRequired" },
                values: new object[,]
                {
                    { new Guid("4e3e5c9f-1db4-47a4-a853-4e5b3c4f9a1d"), 70m, 30m, 1, new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"), false },
                    { new Guid("6e3245b7-6f76-411a-93a1-2c2a4793e12e"), 80m, 50m, 0, new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), true }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType", "BloodTypeLabResultURl", "EmergencyContactName", "EmergencyContactPhone", "Height", "IsActive", "IsDeleted", "PrimaryCarePhysicianId", "Weight" },
                values: new object[,]
                {
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "A-", "http://example.com/lab-results/alice-smith", "Bob Smith", "987-654-3210", 165.2m, false, false, null, 60.8m },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "O+", "http://example.com/lab-results/john-doe", "Jane Doe", "123-456-7890", 180.5m, false, false, null, 75.3m }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "AppointmentStatus", "ConsultationRoom", "ConsultationType", "DoctorId", "HealthCenterId", "IsDeleted", "PatientId" },
                values: new object[,]
                {
                    { new Guid("5f028eff-479b-43dc-9e1b-2e6839c794f8"), new DateTime(2024, 11, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Room 202", 1, new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), false, new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9") },
                    { new Guid("826783f5-dd4f-419e-bb2f-4a8307c54b9b"), new DateTime(2024, 11, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, "Room 101", 0, new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), false, new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950") }
                });

            migrationBuilder.InsertData(
                table: "ClinicalHistories",
                columns: new[] { "Id", "CurrentHistory", "Diagnosis", "DoctorId", "IsDeleted", "PatientId", "PhysicalExamination", "PrescriptionId", "ReasonForVisit", "RegisterDate" },
                values: new object[,]
                {
                    { new Guid("47d713da-eb0f-44c8-bd0d-d1882834c81b"), "Patient reports feeling better with current medication. No new symptoms.", "Diabetes", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), false, new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "\r\n                        Vital Signs: BP 140/90 mmHg, HR 82 bpm, RR 18 bpm, Temp 37.1°C.\r\n                        Anthropometry: Weight 80 kg, Height 1.80 m, BMI 24.7 kg/m².\r\n                        General: Skin warm, no cyanosis or jaundice observed.\r\n                        Cardiovascular: Heart sounds normal, no murmurs detected.\r\n                        Respiratory: Lung fields are clear to auscultation.\r\n                        Abdomen: Non-distended, no tenderness, liver and spleen not palpable.\r\n                        Extremities: No cyanosis or clubbing, peripheral pulses present.\r\n                    ", new Guid("00000000-0000-0000-0000-000000000000"), "Follow-up on medication.", new DateTime(2024, 11, 19, 23, 11, 14, 327, DateTimeKind.Local).AddTicks(6943) },
                    { new Guid("c1aaea0c-c739-4125-a7b3-28da602de5a0"), "No significant issues. Patient reports feeling well overall.", "Hypertension", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), false, new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "\r\n                        Vital Signs: BP 120/80 mmHg, HR 75 bpm, RR 16 bpm, Temp 36.7°C.\r\n                        Anthropometry: Weight 72 kg, Height 1.75 m, BMI 23.5 kg/m².\r\n                        General: Skin and mucosa appear healthy, no lesions observed.\r\n                        Cardiovascular: Regular rhythm, no murmurs detected.\r\n                        Respiratory: Clear breath sounds, no wheezes or crackles.\r\n                        Abdomen: Soft, non-tender, no masses or organomegaly.\r\n                        Extremities: No edema, peripheral pulses are intact.\r\n                    ", new Guid("00000000-0000-0000-0000-000000000000"), "Routine check-up", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DoctorHealthCenters",
                columns: new[] { "Id", "DoctorId", "EntryHour", "ExitHour", "HealthCenterId" },
                values: new object[,]
                {
                    { new Guid("32abd089-92ad-40c0-89a6-cb52ea875809"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "08:00:00", "17:00:00", new Guid("85bc224a-c53f-41db-97b8-92f703ee4452") },
                    { new Guid("f3fae443-e8e0-4c46-8a1b-837bb06a3895"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), "09:00:00", "18:00:00", new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da") }
                });

            migrationBuilder.InsertData(
                table: "DoctorMedicalSpecialties",
                columns: new[] { "Id", "DoctorId", "MedicalSpecialtyId" },
                values: new object[,]
                {
                    { new Guid("075c5bb2-da60-48c7-8eed-ee4624b4daad"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0") },
                    { new Guid("c6a6da44-e5a9-4a2d-84b7-722e983023f0"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("f1a2b3c4-d5e6-789f-0123-456789abcdef") }
                });

            migrationBuilder.InsertData(
                table: "PatientAllergies",
                columns: new[] { "AllergyId", "PatientId", "AllergicReaction", "DiagnosisDate", "Id" },
                values: new object[,]
                {
                    { new Guid("33c7785e-58f4-4ab8-9f54-51bf8978963f"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), "Anaphylaxis", new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0a734b4-18bb-4c64-8f85-54487c656612") },
                    { new Guid("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), "Rash", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a15c2d9b-d758-46b7-aceb-22a163c92a5f") }
                });

            migrationBuilder.InsertData(
                table: "PatientDiscapacities",
                columns: new[] { "DiscapacityId", "PatientId", "DiagnosisDate", "Id", "Severity" },
                values: new object[,]
                {
                    { new Guid("1b54e13f-7a32-4cc1-ad6d-35298426a2fb"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ae6aa623-f515-4b49-a926-5e72369cce77"), "Severa" },
                    { new Guid("5c52a9d3-6ee2-496e-a922-139de857d9d4"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("79dad0d7-f852-486c-a369-9765aafefa86"), "Moderada" }
                });

            migrationBuilder.InsertData(
                table: "PatientHealthInsurances",
                columns: new[] { "HealthInsuranceId", "PatientId", "Id", "PolicyNumber" },
                values: new object[,]
                {
                    { new Guid("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new Guid("df7b9b16-ec96-4b9a-819e-df4b3c7b96c1"), "P0123456789" },
                    { new Guid("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("5f6b3f9a-8d5e-4b2e-ae3f-2c6a78f4f9a1"), "P0987654321" }
                });

            migrationBuilder.InsertData(
                table: "PatientIllnesses",
                columns: new[] { "IllnessId", "PatientId", "DiagnosisDate", "DischargeDate", "DocumentURL", "Id", "Notes", "Status" },
                values: new object[,]
                {
                    { new Guid("1097ba6f-7f4d-4fcc-ae34-f89cf70930a4"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://example.com/document/diabetes-diagnosis.pdf", new Guid("7270f999-7cc5-4cfb-b159-1b732826db15"), "Paciente monitoreado regularmente con niveles de glucosa controlados.", "Activa" },
                    { new Guid("99c26293-7562-4d6a-9aa1-260bedb215a6"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/document/hypertension-diagnosis.pdf", new Guid("8d833c99-76ae-4ad9-a809-c3c235df1ece"), "Paciente responde bien al tratamiento y mantiene una presión estable.", "En remisión" }
                });

            migrationBuilder.InsertData(
                table: "PatientRiskFactors",
                columns: new[] { "PatientId", "RiskFactorId", "Id" },
                values: new object[,]
                {
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new Guid("454e8d39-1363-41f4-a2d2-b99fde743fbf"), new Guid("f68f3e15-994e-4c2d-a3ee-863d753032b0") },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("6522252f-0021-433b-8174-f4e0833f859a"), new Guid("807afcdf-633e-44a9-b688-4f3dd50ab905") }
                });

            migrationBuilder.InsertData(
                table: "PatientVaccines",
                columns: new[] { "PatientId", "VaccineId", "AppliedDoses", "Id", "LastApplicationDate" },
                values: new object[,]
                {
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new Guid("c28e855d-2602-423f-a4d5-26954df029da"), 2, new Guid("12ae1c94-c70d-4379-8cca-e8405a814c6d"), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new Guid("384e34fb-7d23-4123-a78e-13d7b0a91110"), 1, new Guid("086dd520-144e-4afe-98aa-2bf09033048c"), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "ClinicalHistoryId", "OtherPrescriptions" },
                values: new object[,]
                {
                    { new Guid("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"), new Guid("47d713da-eb0f-44c8-bd0d-d1882834c81b"), "Dieta baja en sodio" },
                    { new Guid("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"), new Guid("c1aaea0c-c739-4125-a7b3-28da602de5a0"), "Recomendación de ejercicio diario" }
                });

            migrationBuilder.InsertData(
                table: "AppointmentPrescriptions",
                columns: new[] { "Id", "AppointmentId", "ClinicalHistoryId", "PerformedDate", "PrescriptionId", "ResultUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("b8a5d3f2-4e9a-6b7c-1d2f-5c9e3a7d4f8b"), new Guid("5f028eff-479b-43dc-9e1b-2e6839c794f8"), new Guid("47d713da-eb0f-44c8-bd0d-d1882834c81b"), new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"), "http://example.com/results2.pdf", "Done" },
                    { new Guid("f2d5c7a1-3e4b-8f9d-1a2c-6b3e5d9f4c7a"), new Guid("826783f5-dd4f-419e-bb2f-4a8307c54b9b"), new Guid("c1aaea0c-c739-4125-a7b3-28da602de5a0"), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"), "http://example.com/results1.pdf", "Pending" }
                });

            migrationBuilder.InsertData(
                table: "MedicationPrescriptions",
                columns: new[] { "Id", "Dosage", "MedicationId", "PrescriptionId", "Status", "TreatmentEnd", "TreatmentStart" },
                values: new object[,]
                {
                    { new Guid("c3e2f7a9-1d4b-8f5c-9a6e-2d9b5c3a7f8e"), "500 mg cada 12 horas", new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), new Guid("3a5d9b2e-8c4a-4f7e-9d1c-3f6b2a7d8e9c"), "Consuming", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9f1c3e5-7b6a-4f2c-9a8e-3d5b7a2f8c1e"), "20 mg diario", new Guid("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"), new Guid("2d7a9b5c-1e3a-4b8c-9f7e-5b3d6a1c9e7b"), "Prescribed", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_AppointmentPrescriptions_AppointmentId",
                table: "AppointmentPrescriptions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPrescriptions_ClinicalHistoryId",
                table: "AppointmentPrescriptions",
                column: "ClinicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPrescriptions_PrescriptionId",
                table: "AppointmentPrescriptions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HealthCenterId",
                table: "Appointments",
                column: "HealthCenterId");

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
                name: "IX_ClinicalHistories_DoctorId",
                table: "ClinicalHistories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalHistories_PatientId",
                table: "ClinicalHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHealthCenters_DoctorId",
                table: "DoctorHealthCenters",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHealthCenters_HealthCenterId",
                table: "DoctorHealthCenters",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties",
                column: "MedicalSpecialtyId");

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
                name: "IX_HealthCenterServices_HealthCenterId",
                table: "HealthCenterServices",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_HealthInsuranceId",
                table: "MedicationCoverages",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_MedicationId",
                table: "MedicationCoverages",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_MedicationId",
                table: "MedicationPrescriptions",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_PrescriptionId",
                table: "MedicationPrescriptions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_AllergyId",
                table: "PatientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscapacities_DiscapacityId",
                table: "PatientDiscapacities",
                column: "DiscapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHealthInsurances_HealthInsuranceId",
                table: "PatientHealthInsurances",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId");

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
                name: "IX_PatientVaccines_VaccineId",
                table: "PatientVaccines",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ClinicalHistoryId",
                table: "Prescriptions",
                column: "ClinicalHistoryId",
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
                name: "AppointmentPrescriptions");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "DoctorHealthCenters");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialties");

            migrationBuilder.DropTable(
                name: "FamilyHistories");

            migrationBuilder.DropTable(
                name: "HealthCenterServices");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MedicationCoverages");

            migrationBuilder.DropTable(
                name: "MedicationPrescriptions");

            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.DropTable(
                name: "PatientDiscapacities");

            migrationBuilder.DropTable(
                name: "PatientHealthInsurances");

            migrationBuilder.DropTable(
                name: "PatientIllnesses");

            migrationBuilder.DropTable(
                name: "PatientRiskFactors");

            migrationBuilder.DropTable(
                name: "PatientVaccines");

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
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "MedicalSpecialities");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Discapacities");

            migrationBuilder.DropTable(
                name: "HealthInsurances");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "RiskFactors");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "ClinicalHistories");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
