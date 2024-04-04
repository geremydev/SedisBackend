using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalExamination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelativeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concentration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "PatientAllergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    AllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientVaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedDoses = table.Column<int>(type: "int", nullable: false),
                    LastApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doses = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_ClinicalHistories_ClinicalHistoryId",
                        column: x => x.ClinicalHistoryId,
                        principalTable: "ClinicalHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    TreatmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    ConsultationType = table.Column<int>(type: "int", nullable: false),
                    ConsultationRoom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationCoverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInsuranceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthInsuranceId1 = table.Column<int>(type: "int", nullable: false),
                    MedicationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationId1 = table.Column<int>(type: "int", nullable: false),
                    CoverageStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopayAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoinsurancePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriorAuthorizationRequired = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCoverages_HealthInsurances_HealthInsuranceId1",
                        column: x => x.HealthInsuranceId1,
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
                name: "MedicationPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HealthCenterId",
                table: "Appointments",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_ClinicalHistoryId",
                table: "LabTests",
                column: "ClinicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCoverages_HealthInsuranceId1",
                table: "MedicationCoverages",
                column: "HealthInsuranceId1");

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
                name: "IX_Prescriptions_ClinicalHistoryId",
                table: "Prescriptions",
                column: "ClinicalHistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "FamilyHistories");

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
                name: "PatientVaccines");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "HealthInsurances");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "ClinicalHistories");
        }
    }
}
