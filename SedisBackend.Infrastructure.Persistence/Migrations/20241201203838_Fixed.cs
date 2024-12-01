using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SedisBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("0fcc8a72-809f-4f04-ab4e-1d748a09a793"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("255e9703-be34-4b46-a009-45e10713c16c"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("29016f9b-175e-4014-92b3-64a89f1d06ad"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("2ce1bed5-4432-47b9-abc9-9fb43f62f145"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("5f19609c-db16-4d7d-a77b-bc40c6982ce6"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("f80f32c6-9ebd-44ac-af92-a9b4fffcd072"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("7d5d724e-4aa1-4dcc-bf8c-cd0dc92d0c74"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("be2c3b03-8496-4004-975b-20221b7ded40"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e99a9106-afeb-4a6a-bcd3-cf0c2b13c978"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5a15587-ba4e-45af-9349-2e51f2b4d011"));

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "HealthCenterServices");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatingHours",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "HealthCenterServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "HealthCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationString",
                table: "HealthCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HealthCenters",
                keyColumn: "Id",
                keyValue: new Guid("57efafa6-1eec-4228-b7c1-ab87fe2097da"),
                columns: new[] { "Details", "LocationString" },
                values: new object[] { "Ninguno", "SDE" });

            migrationBuilder.UpdateData(
                table: "HealthCenters",
                keyColumn: "Id",
                keyValue: new Guid("85bc224a-c53f-41db-97b8-92f703ee4452"),
                columns: new[] { "Details", "LocationString" },
                values: new object[] { "Ninguno", "SDE" });

            migrationBuilder.UpdateData(
                table: "HealthCenters",
                keyColumn: "Id",
                keyValue: new Guid("8b971b1f-3f6e-46a8-9b27-805af468bbb4"),
                columns: new[] { "Details", "LocationString" },
                values: new object[] { "Ninguno", "SDE" });

            migrationBuilder.UpdateData(
                table: "HealthCenters",
                keyColumn: "Id",
                keyValue: new Guid("c8b0812e-7205-40ad-a249-fb9e6ae64c37"),
                columns: new[] { "Details", "LocationString" },
                values: new object[] { "Ninguno", "SDE" });

            migrationBuilder.UpdateData(
                table: "HealthCenters",
                keyColumn: "Id",
                keyValue: new Guid("deb707b2-50f1-4245-9f8d-12a3b6e74933"),
                columns: new[] { "Details", "LocationString" },
                values: new object[] { "Ninguno", "SDE" });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(696), new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(707), new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(682), new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(713), new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(702), new DateTime(2024, 12, 1, 20, 38, 37, 107, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.InsertData(
                table: "PatientMedicationPrescription",
                columns: new[] { "Id", "DoctorId", "EndDate", "MedicalConsultationId", "MedicationId", "Notes", "PatientId", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("381b275d-bdbe-4b11-9c31-334893bf0f66"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"), "Tratamiento para hipertensión.", new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("b6b151ef-3486-4390-860e-3edfb672737a"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), "Iniciar tratamiento para controlar la glucosa.", new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("b74ac408-bcaf-4144-8326-dd8da6e70860"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), new Guid("4b2c6894-cc7d-4565-bb18-aba013826de7"), "Tratamiento para depresión y ansiedad.", new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("ca14319d-a930-4c8d-971c-58edafd4477e"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), new Guid("3d69e605-c5e4-42f0-9f00-18f3a12f54ed"), "Control de glucosa en paciente con diabetes tipo 2.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("cb299f86-45a8-4ef4-9061-921cf329db90"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"), "Medicamento para el dolor articular y la inflamación.", new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("fac7042b-f226-4567-b0f7-b8f457711b1a"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), new Guid("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"), "Tratamiento para el dolor abdominal severo y fiebre.", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageURL", "Name" },
                values: new object[,]
                {
                    { new Guid("1ebacd99-687d-428a-b335-4a4ba0c0f2e0"), "Servicio de consulta médica general", "https://example.com/images/general-consultation.jpg", "Consulta General" },
                    { new Guid("21c7dfdc-d1de-4332-bbd3-e97ae1648e80"), "Servicio de imágenes médicas y radiografías", "https://example.com/images/radiology.jpg", "Radiología" },
                    { new Guid("59b84127-98ce-4e0d-9a67-ae091efaa11a"), "Servicio de atención a emergencias médicas", "https://example.com/images/emergencies.jpg", "Emergencias" },
                    { new Guid("e209b5b5-e5fc-4fb0-8247-6b66357da42f"), "Servicio de análisis de laboratorio", "https://example.com/images/laboratory.jpg", "Laboratorio Clínico" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a5b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47950ca8-61d7-45f1-9bf5-4a0eb1227b0f", "AQAAAAIAAYagAAAAEODs1unb5nSu3fZQ8IUfuqJwfiZ4ToryizfbokEhLlYNXSunc41+yl7Y1C2gz5H+QQ==", "acf615af-b17c-4ae6-b37c-84b444fdc5f3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62c2b8a0-3037-4d1e-96aa-3af1118d4fb8", "AQAAAAIAAYagAAAAEH8aLUMkX+JHbdtt23anNqASdu8La8aa5FtO9g7b/z4E3P0W170lPDJLpqUNDLoyDQ==", "0fae4379-12f4-4b50-8ba9-8f3c42329f51" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3524587-2deb-46f8-bcf5-0d47f591bc7e", "AQAAAAIAAYagAAAAEOpahLCs/XmhmH85skoVeAwJ/dBXwlsXBFDflO2KrZONsGhEK7nU8xOeXdv29GFiRA==", "52da3bcb-784f-47ae-98f4-d686cc09238d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c882b001-c58b-43a5-a8dd-c66d09cbbb4c", "AQAAAAIAAYagAAAAEHBef5VB4W7B6BKNZdpYFTF4Y+2LwuJycrdkbQAoN7FQc74UHoL12u5oKkkR1PhzdA==", "40826057-1eef-41de-af6b-06fe72c9ada7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "698bf1b8-09d6-4671-a48f-c7fd3eabeca8", "AQAAAAIAAYagAAAAEN8P1BSpIgsvL+JGO3eZ9E7tiBjAtyLI9qr50xi1IsNa9AJZoUKJXHK6QSokHGRptA==", "1ed53614-705f-415c-bf9a-33b91b3cfbd2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eeb41ce-ae97-4f6b-84d4-95a2964c9392", "AQAAAAIAAYagAAAAEFwENDlJDRVrKNXiTSIYc1VfiSUbNeracf5mbEJ8jFhaq+3KmkDVJgcds660Ivv7hw==", "6cff452d-8118-4263-b60c-3add13dc8f74" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d628655c-0210-4745-a337-965b1fedcff3", "AQAAAAIAAYagAAAAENhDUDq5BVM9cSJVWDESwTalYHxg1hxgKGEbqWEoUsNFGzALlE7uwXmxWhMV+SPH5w==", "c5377926-6705-4349-9ad3-fd03c03bd4e3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12a5a6f9-6aa5-48e0-be6b-67bb7e3cdd86", "AQAAAAIAAYagAAAAEIOZ6k6HMZUlbXvvQdPDnyocq1wgXCV+el+wuu0hE17W9ShUoLWqp6Zj6U34j8UX6Q==", "8ff6ea8a-2760-41e2-b459-707e2720b526" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19eb32af-1d2a-4203-8d7d-22ed553e6a60", "AQAAAAIAAYagAAAAELUA79m0PThZev8efkMHljzWXDhV4AwTeYCEdlAFq1yoM0JMOKyC6HxZGbbzoBHWYw==", "3d5964ac-3dd0-4551-8c4d-e437a0aa0aa4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24ec3cbb-df28-41f3-821e-58474b167a72", "AQAAAAIAAYagAAAAEEY72VhzncZGuTdpuxtO2owBLNoMepHX20SDVqoNXCAi4ShOwvwSOaNtrVb8vsl3Eg==", "e4384e09-b675-4029-b75c-29dd7d5963d4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f97b89c7-aee2-46de-9fa0-7d45840bf34d", "AQAAAAIAAYagAAAAEDBqZDWLLCtd/Txu32SpKJvxqTANNXzJWGlUfUvbvXNmr0WPKKsNyZ1F1W11KBBjmw==", "2a3a9919-2e97-4454-8dac-b4f2181868aa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c5af0ac-2df7-42a2-902c-b0ef39587adf", "AQAAAAIAAYagAAAAEB/ko3xKCkmGmy9Yj+iPtjn5GdoVTBfWM1JQ6L/l8b+lsmSD8qV0R2aFvW+/RuhOSQ==", "26f72bdf-33ad-4248-ad76-f0838f3a74fb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7f87afb-93e3-49c0-a4ad-c7d9af7558b8", "AQAAAAIAAYagAAAAEDrT8UhKdlIwt7O08jKLqbg2ynObfEUJCbC/7W89vqfQU5cLVVdbK1c7GsRr7zmjBA==", "3167b9e3-0713-4478-a13e-38d13d2a70a3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1049153-5ef4-471c-bf70-3d94866fa838", "AQAAAAIAAYagAAAAEOn9eiBMyJrIQGg6EUO4mwtqHqR33ljug6h4FZNZNNxPGQCzAAlbEeJSKktLHAVTow==", "d0b0c38d-2fb5-4bd7-980b-b09f920311da" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c437370-0091-4dea-8efd-200e5ea16a7d", "AQAAAAIAAYagAAAAEIhh+UcQ21L8qCJmeHa7Ya8/QH66ZEZ7UM+WvPLdLRR5L9qVvPUdOXeM8CPB2kYeNQ==", "973eece8-0212-423e-a83f-8b3e0d9ca198" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("381b275d-bdbe-4b11-9c31-334893bf0f66"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("b6b151ef-3486-4390-860e-3edfb672737a"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("b74ac408-bcaf-4144-8326-dd8da6e70860"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("ca14319d-a930-4c8d-971c-58edafd4477e"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("cb299f86-45a8-4ef4-9061-921cf329db90"));

            migrationBuilder.DeleteData(
                table: "PatientMedicationPrescription",
                keyColumn: "Id",
                keyValue: new Guid("fac7042b-f226-4567-b0f7-b8f457711b1a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("1ebacd99-687d-428a-b335-4a4ba0c0f2e0"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("21c7dfdc-d1de-4332-bbd3-e97ae1648e80"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("59b84127-98ce-4e0d-9a67-ae091efaa11a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e209b5b5-e5fc-4fb0-8247-6b66357da42f"));

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "OperatingHours",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "HealthCenterServices");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "HealthCenters");

            migrationBuilder.DropColumn(
                name: "LocationString",
                table: "HealthCenters");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "HealthCenterServices",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "HealthCenterServices",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(59), new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(70), new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(46), new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(76), new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "MedicalConsultations",
                keyColumn: "Id",
                keyValue: new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(65), new DateTime(2024, 12, 1, 12, 22, 40, 577, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.InsertData(
                table: "PatientMedicationPrescription",
                columns: new[] { "Id", "DoctorId", "EndDate", "MedicalConsultationId", "MedicationId", "Notes", "PatientId", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("0fcc8a72-809f-4f04-ab4e-1d748a09a793"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c4f7b60-71a9-4ea8-82f1-7f3c0dbed832"), new Guid("c3a1a1e3-e2b5-42ac-8b34-358ea7745d6e"), "Tratamiento para el dolor abdominal severo y fiebre.", new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("255e9703-be34-4b46-a009-45e10713c16c"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a8b5e23-3f6b-4315-bf4e-8b7e1a5b15bc"), new Guid("3d69e605-c5e4-42f0-9f00-18f3a12f54ed"), "Control de glucosa en paciente con diabetes tipo 2.", new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("29016f9b-175e-4014-92b3-64a89f1d06ad"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("f1c839fa-d3f8-433d-b6e3-e8d5296d22d9"), "Medicamento para el dolor articular y la inflamación.", new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("2ce1bed5-4432-47b9-abc9-9fb43f62f145"), new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d4e8a71-17a5-45c7-bec6-a7934c0425bc"), new Guid("4b2c6894-cc7d-4565-bb18-aba013826de7"), "Tratamiento para depresión y ansiedad.", new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5f19609c-db16-4d7d-a77b-bc40c6982ce6"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f7319e7-89b4-4d5c-90cb-cf2e5a0c9fbd"), new Guid("e4c9b8d4-9a5d-44d3-9be7-85e2e57b73c1"), "Tratamiento para hipertensión.", new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f80f32c6-9ebd-44ac-af92-a9b4fffcd072"), new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d2e7a36-91e8-4b4a-a769-854fa9d4cb29"), new Guid("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"), "Iniciar tratamiento para controlar la glucosa.", new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "ImageURL", "Name" },
                values: new object[,]
                {
                    { new Guid("7d5d724e-4aa1-4dcc-bf8c-cd0dc92d0c74"), "Servicio de imágenes médicas y radiografías", "https://example.com/images/radiology.jpg", "Radiología" },
                    { new Guid("be2c3b03-8496-4004-975b-20221b7ded40"), "Servicio de análisis de laboratorio", "https://example.com/images/laboratory.jpg", "Laboratorio Clínico" },
                    { new Guid("e99a9106-afeb-4a6a-bcd3-cf0c2b13c978"), "Servicio de atención a emergencias médicas", "https://example.com/images/emergencies.jpg", "Emergencias" },
                    { new Guid("f5a15587-ba4e-45af-9349-2e51f2b4d011"), "Servicio de consulta médica general", "https://example.com/images/general-consultation.jpg", "Consulta General" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a5b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe263e8-6438-4833-8bac-fa7dc93b3e90", "AQAAAAIAAYagAAAAEDR8adRJy33hyq32HArUDAU6xsGyFeWyrdnpIzCyxbPvBJ7WUnwrx70q8My2WnoOgg==", "ae78402f-8a62-4372-a835-4127e587c15d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b8bedb7-fac4-46b2-92ff-ecbc34bfa3b3", "AQAAAAIAAYagAAAAEMPKne2R/llPZgzlASzE0Gm1Pq3xR/l1+w3UelYM4EmdLFkpE+52wKej+F4ymEjTsA==", "109aa265-e86c-4aac-9bd9-10e2cec50f68" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8354fc07-0616-4a9a-ba8c-fbfcd133ae26", "AQAAAAIAAYagAAAAEGbHhOPR1p87DPA4/exriVU0M1Atx9jd731q4yyQ9T4ghpUCF2RHYgJBJOKakBzFCQ==", "99d027ab-88d7-4c69-b6bf-8370f8aede44" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b314a0e0-0349-47e4-b742-7dd230c27ce0", "AQAAAAIAAYagAAAAEE0Eq46grVh1gqJx9wJUHi8xXZ9L5fzde0EBD2nqdr/pXTsuAGiuY3U5Id6qmQuqRQ==", "e5d734b2-8c9b-4121-a24f-dfcb766d747e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe49017a-fbee-4249-b35c-39982595c2a7", "AQAAAAIAAYagAAAAENzQQdOBIcwd1az8qUjCNKZzjhWZ+lMBsFXdcalQelaZfmdkvLTRyNygekf0opdV+g==", "b5e732b9-18f3-4b04-b4b8-c0c1efb5df45" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0030c796-ca68-4a88-a921-b006396388ce", "AQAAAAIAAYagAAAAEIAhM+3w7PoDOfqJHB9Nb9X/r5Cg4yC1dHNCruDIlODOO7h3E7R2Zhy70Fyp5qOT+A==", "ef8723ce-93fa-437a-9367-12b57b0a2114" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6be3ba80-c25f-4142-80bd-1d875a787fa8", "AQAAAAIAAYagAAAAEKzsoiSJBw2Z0pXW0ov+q5YHiPiUUW8kH2zNJlWkHm0iMqSuG7HnIAheclrBGHH9bQ==", "74da3a63-3886-4a39-a827-c288014d50dd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ee6c546-b491-41ae-9b84-101e96b224e0", "AQAAAAIAAYagAAAAEKgVq6+YtQEQzAUb8mf8EaiHoTMUYFbjRteZhY+j/tT7qmSh1sSf1N+LLQLN0me9BA==", "5725fa7c-14af-4e12-a88e-9d85f529fce2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67581db4-42ef-4669-9866-40c919ecf2e9", "AQAAAAIAAYagAAAAEFz3wiCC/SgehBNpdjkGaB1cv0QKdGZHtVJX7jvOxR76wLuxiJUYqRH8eiHFEcOaMw==", "6eaf15d4-723c-44eb-9474-8244e375c095" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeedbef8-0c96-4571-b9f8-b3563e8bb880", "AQAAAAIAAYagAAAAEK6BGHvnntfW9Cn+Rh2XmlS5eIGk0urWW4wxQn8OFUv4X77Y6+3PCN6eKv7CSfVE8Q==", "53db3283-cb02-4e1a-bc60-9e299f0dcb3f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bf91a7b-afbb-4bf3-b269-49e24800ca5b", "AQAAAAIAAYagAAAAELkkr8AQNJg2az+R7j705SIexmGzlEPNrE6wHm/rky4CazMq0lRmBc58hF+0iUG5aQ==", "f262f54d-b500-4567-93cc-3244a399d480" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91fe5e96-5d70-4a4f-ab94-b5b6eddfc91f", "AQAAAAIAAYagAAAAEG+SbzJdfYGVYtevFff2/X1IZ6/2jO09gQt2cLo4/vh7fcaQ1ciEo348LaqY9hgMzg==", "cbb53814-ca8c-4ea7-b3d1-1c33ca61a92a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a076b37-14b1-4884-bf05-e8783ca72ab9", "AQAAAAIAAYagAAAAEDt2GGMX259BgulEUb8L3vtr9ozgJbjJVENt6qaY3eORQ3kr3jYBlm2fglEInJEGxg==", "9e76ebb9-99c2-47e3-8660-34f79d4b44d6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dd64f35-57e4-4696-a4e6-e5217d066cb1", "AQAAAAIAAYagAAAAEB0a2q+A9WYx2enWsvH9s4AehnNkTqimOxWbCSNcUBlyJrBhXVZa602Su7F9UnL9yA==", "022869ef-e578-44b4-b020-3dbef776557e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34ab5a59-5b1c-474b-b09f-a2c4860ea913", "AQAAAAIAAYagAAAAECoRLUNWiz0JXvKiVAoijtfELUil96DlFybIZ5JReBH4o3vuX7iqpa0Fv+zZSi5Vqw==", "db23a82e-dda5-4088-85cd-f77671b0318b" });
        }
    }
}
