using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SedisBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Allergen = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
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
                    PolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverageLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concentration = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteOfAdministration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraindications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugInteractions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntityRelation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntityRelation", x => x.Id);
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistants_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorHealthCenters_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_MedicalSpecialities_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationCoverages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopayAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CoinsurancePercentage = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
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
                        name: "FK_MedicationCoverages_Medications_MedicationId1",
                        column: x => x.MedicationId1,
                        principalTable: "Medications",
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
                    AppointmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationRoom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalHistories_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelativeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelativeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyHistories_Patients_RelativeId1",
                        column: x => x.RelativeId1,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiscapacities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscapacityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiscapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDiscapacities_Discapacities_DiscapacityId",
                        column: x => x.DiscapacityId,
                        principalTable: "Discapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiscapacities_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientHealthInsurance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthInsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHealthInsurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurance_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientHealthInsurance_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientIllnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IllnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientRiskFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskFactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRiskFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRiskFactors_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientRiskFactors_RiskFactors_RiskFactorId",
                        column: x => x.RiskFactorId,
                        principalTable: "RiskFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientVaccines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedDoses = table.Column<int>(type: "int", nullable: false),
                    LastApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientVaccines_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "LabTestPrescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicalHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestPrescriptions_ClinicalHistories_ClinicalHistoryId",
                        column: x => x.ClinicalHistoryId,
                        principalTable: "ClinicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTestPrescriptions_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTestPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                table: "Doctors",
                columns: new[] { "Id", "Birthdate", "FirstName", "IdCard", "IsActive", "LastName", "LicenseNumber", "Sex" },
                values: new object[,]
                {
                    { new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "1234567890", true, "Doe", "LIC12345678", "M" },
                    { new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "0987654321", false, "Smith", "LIC98765432", "F" }
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
                table: "MedicalSpecialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), "Focuses on the diagnosis and treatment of neurological disorders.", "Neurology" },
                    { new Guid("f1a2b3c4-d5e6-789f-0123-456789abcdef"), "Specializes in the treatment of heart conditions.", "Cardiology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthdate", "BloodType", "BloodTypeLabResultURl", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "Height", "IdCard", "IsActive", "LastName", "PrimaryCarePhysicianId", "Sex", "Weight" },
                values: new object[,]
                {
                    { new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O+", "http://example.com/lab-results/john-doe", "Jane Doe", "123-456-7890", "John", 180.5m, "40211608647", false, "Doe", null, " ", 75.3m },
                    { new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A-", "http://example.com/lab-results/alice-smith", "Bob Smith", "987-654-3210", "Alice", 165.2m, "40211608648", false, "Smith", null, " ", 60.8m }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "AppointmentStatus", "ConsultationRoom", "ConsultationType", "DoctorId", "HealthCenterId", "PatientId" },
                values: new object[,]
                {
                    { new Guid("825eb1e3-62c1-4232-b301-758930e29df9"), new DateTime(2024, 11, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "completed", "Room 202", "follow-up", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9") },
                    { new Guid("b87e571e-d964-43db-996b-e2f4f6265c46"), new DateTime(2024, 11, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "scheduled", "Room 101", "general checkup", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950") }
                });

            migrationBuilder.InsertData(
                table: "ClinicalHistories",
                columns: new[] { "Id", "CurrentHistory", "Diagnosis", "DoctorId", "PatientId", "PhysicalExamination", "PrescriptionId", "ReasonForVisit", "RegisterDate" },
                values: new object[,]
                {
                    { new Guid("04f5b044-5052-4844-94c7-5c9b026f258a"), "No significant issues.", "Hypertension", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Routine check-up", new DateTime(2024, 10, 16, 15, 49, 0, 953, DateTimeKind.Local).AddTicks(6408) },
                    { new Guid("67232939-a019-4a3f-936e-cbe77fa4ef60"), "Feeling better.", "Diabetes", new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Follow-up on medication.", new DateTime(2024, 10, 16, 15, 49, 0, 953, DateTimeKind.Local).AddTicks(6457) }
                });

            migrationBuilder.InsertData(
                table: "DoctorHealthCenters",
                columns: new[] { "Id", "DoctorId", "EntryHour", "ExitHour", "HealthCenterId" },
                values: new object[,]
                {
                    { new Guid("3fe6d186-36d7-4a19-8f11-e93f2ab242e0"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), "08:00:00", "17:00:00", new Guid("85bc224a-c53f-41db-97b8-92f703ee4452") },
                    { new Guid("e933e060-fe8f-4026-9774-97accb2124d4"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), "09:00:00", "18:00:00", new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da") }
                });

            migrationBuilder.InsertData(
                table: "DoctorMedicalSpecialties",
                columns: new[] { "Id", "DoctorId", "MedicalSpecialtyId" },
                values: new object[,]
                {
                    { new Guid("308db8b0-c508-4232-bb22-b2b41f1b3e44"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0") },
                    { new Guid("a5ebc75d-4052-4e04-b0af-de4ff82e64e0"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new Guid("f1a2b3c4-d5e6-789f-0123-456789abcdef") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_HealthCenterId",
                table: "Admins",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdCard",
                table: "Admins",
                column: "IdCard",
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
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_HealthCenterId",
                table: "Assistants",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_IdCard",
                table: "Assistants",
                column: "IdCard",
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
                name: "IX_Doctors_IdCard",
                table: "Doctors",
                column: "IdCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistories_PatientId",
                table: "FamilyHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistories_RelativeId1",
                table: "FamilyHistories",
                column: "RelativeId1");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenterServices_HealthCenterId",
                table: "HealthCenterServices",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestPrescriptions_ClinicalHistoryId",
                table: "LabTestPrescriptions",
                column: "ClinicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestPrescriptions_LabTestId",
                table: "LabTestPrescriptions",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestPrescriptions_PrescriptionId",
                table: "LabTestPrescriptions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_HealthInsuranceId",
                table: "MedicationCoverages",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_MedicationId1",
                table: "MedicationCoverages",
                column: "MedicationId1");

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
                name: "IX_PatientAllergies_PatientId",
                table: "PatientAllergies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscapacities_DiscapacityId",
                table: "PatientDiscapacities",
                column: "DiscapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscapacities_PatientId",
                table: "PatientDiscapacities",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHealthInsurance_HealthInsuranceId",
                table: "PatientHealthInsurance",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHealthInsurance_PatientId",
                table: "PatientHealthInsurance",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_PatientId",
                table: "PatientIllnesses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRiskFactors_PatientId",
                table: "PatientRiskFactors",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRiskFactors_RiskFactorId",
                table: "PatientRiskFactors",
                column: "RiskFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdCard",
                table: "Patients",
                column: "IdCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccines_PatientId",
                table: "PatientVaccines",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVaccines_VaccineId",
                table: "PatientVaccines",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ClinicalHistoryId",
                table: "Prescriptions",
                column: "ClinicalHistoryId",
                unique: true);
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
                name: "DoctorHealthCenters");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialties");

            migrationBuilder.DropTable(
                name: "FamilyHistories");

            migrationBuilder.DropTable(
                name: "HealthCenterServices");

            migrationBuilder.DropTable(
                name: "LabTestPrescriptions");

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
                name: "PatientHealthInsurance");

            migrationBuilder.DropTable(
                name: "PatientIllnesses");

            migrationBuilder.DropTable(
                name: "PatientRiskFactors");

            migrationBuilder.DropTable(
                name: "PatientVaccines");

            migrationBuilder.DropTable(
                name: "UserEntityRelation");

            migrationBuilder.DropTable(
                name: "MedicalSpecialities");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "LabTests");

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
                name: "ClinicalHistories");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
