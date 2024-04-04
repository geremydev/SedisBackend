using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Clinical_History;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Presctiptions;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Infrastructure.Persistence.Contexts
{
    public class SedisContext: DbContext
    {
        public SedisContext(DbContextOptions<SedisContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<MedicationCoverage> MedicationCoverages { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<DoctorMedicalSpeciality> DoctorMedicalSpecialities { get; set; }


        #region Historial Clinico
        public DbSet<ClinicalHistory> ClinicalHistories { get; set; }
        public DbSet<FamilyHistory> FamilyHistories { get; set; }
        public DbSet<LabTest> LabTests { get; set; }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationPrescription> MedicationPrescriptions { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<PatientVaccine> PatientVaccines { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Nombres de tablas
            modelBuilder.Entity<HealthCenter>().ToTable("HealthCenters");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<HealthInsurance>().ToTable("HealthInsurances");
            modelBuilder.Entity<MedicationCoverage>().ToTable("MedicationCoverages");
            modelBuilder.Entity<Location>().ToTable("Locations");

            #region Medical History
            modelBuilder.Entity<ClinicalHistory>().ToTable("ClinicalHistories");
            modelBuilder.Entity<FamilyHistory>().ToTable("FamilyHistories");
            modelBuilder.Entity<LabTest>().ToTable("LabTests");
            modelBuilder.Entity<Medication>().ToTable("Medications");
            modelBuilder.Entity<MedicationPrescription>().ToTable("MedicationPrescriptions");
            modelBuilder.Entity<Prescription>().ToTable("Prescriptions");
            modelBuilder.Entity<Allergy>().ToTable("Allergies");
            modelBuilder.Entity<PatientAllergy>().ToTable("PatientAllergies");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccines");
            modelBuilder.Entity<PatientVaccine>().ToTable("PatientVaccines");
            #endregion

            #endregion

            #region Primary Keys
            modelBuilder.Entity<HealthCenter>().HasKey(p => p.Id);
            modelBuilder.Entity<Appointment>().HasKey(p => p.Id);
            modelBuilder.Entity<HealthInsurance>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicationCoverage>().HasKey(p => p.Id);
            modelBuilder.Entity<ClinicalHistory>().HasKey(p => p.Id);
            modelBuilder.Entity<FamilyHistory>().HasKey(p => p.Id);
            modelBuilder.Entity<LabTest>().HasKey(p => p.Id);
            modelBuilder.Entity<Medication>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicationPrescription>().HasKey(p => p.Id);
            modelBuilder.Entity<Prescription>().HasKey(p => p.Id);
            modelBuilder.Entity<Allergy>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientAllergy>().HasKey(p => p.Id);
            modelBuilder.Entity<Vaccine>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientVaccine>().HasKey(p => p.Id);
            modelBuilder.Entity<Location>().HasKey(p => p.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<Doctor>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicalSpeciality>().HasKey(p => p.Id);
            modelBuilder.Entity<DoctorMedicalSpeciality>().HasKey(p => p.Id);
            #endregion

            #region Relations
            modelBuilder.Entity<ClinicalHistory>()
                .HasMany(r => r.Prescriptions)
                .WithOne(r => r.ClinicalHistory)
                .HasForeignKey(r => r.ClinicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClinicalHistory>()
                .HasMany(r => r.LabTests)
                .WithOne(r => r.ClinicalHistory)
                .HasForeignKey(r => r.ClinicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthCenter>()
                .HasMany(k => k.Appointments)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<ClinicalHistory>()
                .HasMany(k => k.Prescriptions)
                .WithOne(k => k.ClinicalHistory)
                .HasForeignKey(k => k.ClinicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClinicalHistory>()
                .HasMany(k => k.LabTests)
                .WithOne(k => k.ClinicalHistory)
                .HasForeignKey(k => k.ClinicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasMany(k => k.PrescribedMedications)
                .WithOne(k => k.Prescription)
                .HasForeignKey(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
