using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Locations;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.UserEntityRelation;
using SedisBackend.Core.Domain.Users.Admins;
using SedisBackend.Core.Domain.Users.Assistants;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;
using SedisBackend.Infrastructure.Persistence.Configuration;

namespace SedisBackend.Infrastructure.Persistence.Contexts
{
    public class SedisContext : DbContext
    {
        public SedisContext(DbContextOptions<SedisContext> options) : base(options) { }

        #region DbSet Definitions

        #region Appointments
        public DbSet<Appointment> Appointments { get; set; }

        #endregion

        #region HealthCenters
        public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<HealthCenterServices> HealthCenterServices { get; set; }

        #endregion

        #region Medical History

        #region Allergies
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }
        #endregion

        #region Clinical History
        public DbSet<ClinicalHistory> ClinicalHistories { get; set; }
        #endregion

        #region Family History
        public DbSet<FamilyHistory> FamilyHistories { get; set; }

        #endregion

        #region Medical Conditions

        #region Discapacity Condition
        public DbSet<Discapacity> Discapacities { get; set; }
        public DbSet<PatientDiscapacity> PatientDiscapacities { get; set; }
        #endregion

        #region Illness Condition
        public DbSet<Illness> illnesses { get; set; }
        public DbSet<PatientIllness> PatientIllnesses { get; set; }
        #endregion

        #region RiskFactor
        public DbSet<PatientRiskFactor> PatientRiskFactors { get; set; }
        public DbSet<RiskFactor> RiskFactors { get; set; }
        #endregion

        #endregion

        #region Vaccines
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<PatientVaccine> PatientVaccines { get; set; }
        #endregion

        #endregion

        #region Medical Insurance
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<MedicationCoverage> MedicationCoverages { get; set; }
        #endregion

        #region Presctiption
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicationPrescription> MedicationPrescriptions { get; set; }
        public DbSet<LabTestPrescription> LabTestPrescriptions { get; set; }

        #endregion

        #region Products
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Medication> Medications { get; set; }
        #endregion

        #region UserEntityRelation
        public DbSet<UserEntityRelation> UserEntityRelation { get; set; }

        #endregion

        #region Users

        #region Patient
        public DbSet<Patient> Patients { get; set; }
        #endregion

        #region Doctor
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorHealthCenter> DoctorHealthCenters { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialities { get; set; }
        public DbSet<DoctorMedicalSpecialty> DoctorMedicalSpecialities { get; set; }
        #endregion

        #endregion

        #region Location
        public DbSet<Location> Locations { get; set; }
        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Table names

            #region Appointments    
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            #endregion

            #region HealthCenters
            modelBuilder.Entity<HealthCenter>().ToTable("HealthCenters");
            modelBuilder.Entity<HealthCenterServices>().ToTable("HealthCenterServices");
            #endregion

            #region Location
            modelBuilder.Entity<Location>().ToTable("Locations");
            #endregion

            #region Medical History

            #region Allergies
            modelBuilder.Entity<Allergy>().ToTable("Allergies");
            modelBuilder.Entity<PatientAllergy>().ToTable("PatientAllergies");
            #endregion

            #region Clinical History
            modelBuilder.Entity<ClinicalHistory>().ToTable("ClinicalHistories");
            #endregion

            #region Family History
            modelBuilder.Entity<FamilyHistory>().ToTable("FamilyHistories");
            #endregion

            #region Medical Conditions

            #region Discapacity Condition
            modelBuilder.Entity<Discapacity>().ToTable("Discapacities");
            modelBuilder.Entity<PatientDiscapacity>().ToTable("PatientDiscapacities");
            #endregion

            #region Illness Condition
            modelBuilder.Entity<Illness>().ToTable("Illnesses");
            modelBuilder.Entity<PatientIllness>().ToTable("PatientIllnesses");

            #endregion

            #region RiskFactor
            modelBuilder.Entity<RiskFactor>().ToTable("RiskFactors");
            modelBuilder.Entity<PatientRiskFactor>().ToTable("PatientRiskFactors");
            #endregion

            #endregion

            #region Vaccines
            modelBuilder.Entity<PatientVaccine>().ToTable("PatientVaccines");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccines");

            #endregion

            #endregion

            #region Medical Insurance
            modelBuilder.Entity<HealthInsurance>().ToTable("HealthInsurances");
            modelBuilder.Entity<MedicationCoverage>().ToTable("MedicationCoverages");
            #endregion

            #region UserEntityRelation

            modelBuilder.Entity<UserEntityRelation>().ToTable("UserEntityRelation");

            #endregion

            #region Presctiption
            modelBuilder.Entity<MedicationPrescription>().ToTable("MedicationPrescriptions");
            modelBuilder.Entity<LabTestPrescription>().ToTable("LabTestPrescriptions");
            modelBuilder.Entity<Prescription>().ToTable("Prescriptions");
            #endregion

            #region Products
            modelBuilder.Entity<LabTest>().ToTable("LabTests");
            modelBuilder.Entity<Medication>().ToTable("Medications");
            #endregion

            #region Users

            #region Patient
            modelBuilder.Entity<Patient>().ToTable("Patients");
            #endregion

            #region Doctor
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<DoctorHealthCenter>().ToTable("DoctorHealthCenters");
            modelBuilder.Entity<MedicalSpecialty>().ToTable("MedicalSpecialities");
            modelBuilder.Entity<DoctorMedicalSpecialty>().ToTable("DoctorMedicalSpecialities");
            #endregion

            #region Admin
            modelBuilder.Entity<Admin>().ToTable("Admins");
            #endregion

            #region Assistant
            modelBuilder.Entity<Assistant>().ToTable("Assistants");
            #endregion

            #endregion

            #endregion

            #region Primary Keys

            #region Appointments    
            modelBuilder.Entity<Appointment>().HasKey(p => p.Id);
            #endregion

            #region HealthCenters
            modelBuilder.Entity<HealthCenter>().HasKey(p => p.Id);
            modelBuilder.Entity<HealthCenterServices>().HasKey(p => p.Id);
            #endregion

            #region Location
            modelBuilder.Entity<Location>().HasKey(p => p.Id);
            #endregion

            #region Medical History
            #region Allergies
            modelBuilder.Entity<Allergy>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientAllergy>().HasKey(p => p.Id);
            #endregion

            #region Clinical History
            modelBuilder.Entity<ClinicalHistory>().HasKey(p => p.Id);
            #endregion

            #region Family History
            modelBuilder.Entity<FamilyHistory>().HasKey(p => p.Id);
            #endregion

            #region Medical Conditions

            #region Discapacity Condition
            modelBuilder.Entity<Discapacity>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientDiscapacity>().HasKey(p => p.Id);
            #endregion

            #region Illness Condition
            modelBuilder.Entity<Illness>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientIllness>().HasKey(p => p.Id);
            #endregion

            #region RiskFactor
            modelBuilder.Entity<RiskFactor>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientRiskFactor>().HasKey(p => p.Id);
            #endregion

            #endregion

            #region Vaccines
            modelBuilder.Entity<Vaccine>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientVaccine>().HasKey(p => p.Id);
            #endregion

            #endregion

            #region UserEntityRelation 
            modelBuilder.Entity<UserEntityRelation>()
            .HasKey(p => p.Id);
            #endregion

            #region Medical Insurance
            modelBuilder.Entity<HealthInsurance>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicationCoverage>().HasKey(p => p.Id);
            #endregion

            #region Presctiption
            modelBuilder.Entity<Prescription>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicationPrescription>().HasKey(p => p.Id);
            modelBuilder.Entity<LabTestPrescription>().HasKey(p => p.Id);
            #endregion

            #region Products
            modelBuilder.Entity<LabTest>().HasKey(p => p.Id);
            modelBuilder.Entity<Medication>().HasKey(p => p.Id);
            #endregion

            #region Users
            #region Patient
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            #endregion

            #region Doctor
            modelBuilder.Entity<Doctor>().HasKey(p => p.Id);
            modelBuilder.Entity<MedicalSpecialty>().HasKey(p => p.Id);
            modelBuilder.Entity<DoctorMedicalSpecialty>().HasKey(p => p.Id);
            modelBuilder.Entity<DoctorHealthCenter>().HasKey(p => p.Id);

            #endregion

            #region Admin
            modelBuilder.Entity<Admin>().HasKey(p => p.Id);
            #endregion

            #region Assistant
            modelBuilder.Entity<Assistant>().HasKey(p => p.Id);
            #endregion
            #endregion


            #endregion

            #region Relations

            #region Appointments    
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.HealthCenter)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region HealthCenters
            modelBuilder.Entity<HealthCenter>()
                .HasMany(k => k.Appointments)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthCenter>()
                .HasMany(k => k.Doctors)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthCenter>()
                .HasMany(k => k.Admins)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthCenter>()
                .HasMany(k => k.Assistants)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HealthCenter>() //Los servicios deberían estar normalizados ya que el mismo servicio puede ser ofrecido por distintos Centros de salud.
                .HasMany(k => k.Services)
                .WithOne(k => k.HealthCenter)
                .HasForeignKey(k => k.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Location
            #endregion

            #region Medical History
            #region Allergies
            modelBuilder.Entity<Allergy>()
                .HasMany(k => k.Patients)
                .WithOne(k => k.Allergy)
                .HasForeignKey(k => k.AllergyId);
            #endregion

            #region Clinical History
            modelBuilder.Entity<ClinicalHistory>()
                .HasOne(k => k.Prescription)
                .WithOne(k => k.ClinicalHistory)
                .HasForeignKey<ClinicalHistory>(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Family History
            #endregion

            #region Medical Conditions

            #region Discapacity Condition
            #endregion

            #region Illness Condition
            #endregion

            #region RiskFactor
            #endregion

            #endregion

            #region Vaccines
            #endregion

            #endregion

            #region Medical Insurance
            modelBuilder.Entity<HealthInsurance>()
                .HasMany(k => k.MedicationCoverages)
                .WithOne(k => k.HealthInsurance)
                .HasForeignKey(k => k.HealthInsuranceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HealthInsurance>()
                .HasMany(k => k.SubscribedPatients)
                .WithOne(k => k.HealthInsurance)
                .HasForeignKey(k => k.HealthInsuranceId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Presctiption
            modelBuilder.Entity<Prescription>()
                .HasMany(k => k.PrescribedMedications)
                .WithOne(k => k.Prescription)
                .HasForeignKey(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasMany(k => k.PrescribedLabTests)
                .WithOne(k => k.Prescription)
                .HasForeignKey(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.ClinicalHistory)
                .WithOne(k => k.Prescription)
                .HasForeignKey<Prescription>(k => k.ClinicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<MedicationPrescription>().ToTable("MedicationPrescriptions");
            //modelBuilder.Entity<LabTestPrescription>().ToTable("LabTestPrescriptions");

            #endregion

            #region Products
            #endregion

            #region Users
            #region Patient
            modelBuilder.Entity<Patient>()
                .HasMany(k => k.ClinicalHistories)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.Appointments)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.Allergies)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.Illnesses)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.RiskFactors)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.Discapacities)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.Vaccines)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(k => k.FamilyHistories)
                .WithOne(k => k.Patient)
                .HasForeignKey(k => k.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Doctor
            modelBuilder.Entity<Doctor>()
                .HasMany(k => k.Appointments)
                .WithOne(k => k.Doctor)
                .HasForeignKey(k => k.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasMany(k => k.CurrentlyWorkingHealthCenters)
                .WithOne(k => k.Doctor)
                .HasForeignKey(k => k.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
               .HasMany(k => k.Specialties)
               .WithOne(k => k.Doctor)
               .HasForeignKey(k => k.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
              .HasMany(k => k.DevelopedClinicalHistories)
              .WithOne(k => k.Doctor)
              .HasForeignKey(k => k.DoctorId)
              .OnDelete(DeleteBehavior.Cascade);

            //public ICollection<DoctorHealthCenter> CurrentlyWorkingHealthCenters { get; set; }
            //public ICollection<DoctorMedicalSpecialty> Specialties { get; set; }
            //public ICollection<Appointment> Appointments { get; set; }
            //public ICollection<ClinicalHistory> DevelopedClinicalHistories { get; set; }
            #endregion

            #endregion


            #endregion

            #region Properties

            #region Doctor
            modelBuilder.Entity<DoctorHealthCenter>()
                .Property(e => e.EntryHour)
                .HasConversion(
                    v => TimeSpanToString(v),
                    v => StringToTimeSpan(v)
                );

            modelBuilder.Entity<DoctorHealthCenter>()
                .Property(e => e.ExitHour)
                .HasConversion(
                    v => TimeSpanToString(v),
                    v => StringToTimeSpan(v)
                );
            modelBuilder.Entity<Doctor>()
                .HasIndex(p => p.IdCard)
                .IsUnique();
            #endregion

            #region Patient
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.IdCard)  // Consider adding an index for performance
                .IsUnique();
            #endregion

            #region Assistant
            modelBuilder.Entity<Assistant>()
                .HasIndex(p => p.IdCard)
                .IsUnique();
            #endregion

            #region Admin
            modelBuilder.Entity<Admin>()
                .HasIndex(p => p.IdCard)
                .IsUnique();
            #endregion

            #region Location
            modelBuilder.Entity<Location>()
               .Property(l => l.Latitude)
               .HasColumnType("decimal(10, 8)");
            modelBuilder.Entity<Location>()
                .Property(l => l.Longitude)
                .HasColumnType("decimal(11, 8)");
            #endregion

            #region MedicationCoverage
            modelBuilder.Entity<MedicationCoverage>(builder =>
            {
                builder.Property(mc => mc.CopayAmount)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                builder.Property(mc => mc.CoinsurancePercentage)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();
            });
            #endregion

            #region Medication
            modelBuilder.Entity<Medication>()
                .Property(m => m.Concentration)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Patient
            modelBuilder.Entity<Patient>()
               .Property(p => p.Height)
               .HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Patient>()
                .Property(p => p.Weight)
                .HasColumnType("decimal(5, 2)"); ;
            #endregion

            #endregion

            #region Configurations

            // Configuraciones relacionadas con el paciente y sus atributos
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientAllergyConfiguration());
            modelBuilder.ApplyConfiguration(new PatientDiscapacityConfiguration());
            modelBuilder.ApplyConfiguration(new PatientHealthInsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new PatientIllnessConfiguration());
            modelBuilder.ApplyConfiguration(new PatientRiskFactorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientVaccineConfiguration());

            // Configuraciones relacionadas con el historial clínico y prescripciones
            modelBuilder.ApplyConfiguration(new ClinicalHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new MedicationPrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new LabTestPrescriptionConfiguration());

            // Configuraciones relacionadas con citas y servicios médicos
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new HealthCenterConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorHealthCenterConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorMedicalSpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalSpecialtyConfiguration());

            // Configuraciones de entidades secundarias y auxiliares
            modelBuilder.ApplyConfiguration(new AssistantConfiguration());
            modelBuilder.ApplyConfiguration(new HealthInsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new AllergyConfiguration());
            modelBuilder.ApplyConfiguration(new IllnessConfiguration());
            modelBuilder.ApplyConfiguration(new DiscapacityConfiguration());
            modelBuilder.ApplyConfiguration(new RiskFactorConfiguration());
            modelBuilder.ApplyConfiguration(new VaccineConfiguration());

            // Configuraciones de laboratorios y medicamentos
            modelBuilder.ApplyConfiguration(new LabTestConfiguration());
            modelBuilder.ApplyConfiguration(new MedicationConfiguration());
            modelBuilder.ApplyConfiguration(new MedicationCoverageConfiguration());

            #endregion
        }

        private static string TimeSpanToString(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        private static TimeSpan StringToTimeSpan(string timeString)
        {
            if (TimeSpan.TryParse(timeString, out var timeSpan))
            {
                return timeSpan;
            }

            // Return a default value (e.g., TimeSpan.Zero) or throw an exception
            return TimeSpan.Zero; // or throw new FormatException("Invalid TimeSpan format");
        }
    }
}
