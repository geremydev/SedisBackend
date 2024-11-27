using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Configuration;

namespace SedisBackend.Infrastructure.Persistence.Contexts;

public class SedisContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public SedisContext(DbContextOptions options)
        : base(options)
    {
    }

    #region Tables
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<HealthCenter> HealthCenters { get; set; }
    public DbSet<HealthCenterServices> HealthCenterServices { get; set; }
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<PatientAllergy> PatientAllergies { get; set; }
    public DbSet<MedicalConsultation> ClinicalHistories { get; set; }
    public DbSet<FamilyHistory> FamilyHistories { get; set; }
    public DbSet<Discapacity> Discapacities { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MedicalSpecialty> MedicalSpecialities { get; set; }
    public DbSet<Illness> Illnesses { get; set; }
    public DbSet<RiskFactor> RiskFactors { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<HealthInsurance> HealthInsurances { get; set; }
    public DbSet<MedicationCoverage> MedicationCoverages { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<PatientDiscapacity> PatientDiscapacities { get; set; }
    public DbSet<PatientIllness> PatientIllnesses { get; set; }
    public DbSet<PatientRiskFactor> PatientRiskFactors { get; set; }
    public DbSet<PatientVaccine> PatientVaccines { get; set; }
    public DbSet<PatientHealthInsurance> PatientHealthInsurances { get; set; }
    public DbSet<MedicationPrescription> MedicationPrescriptions { get; set; }
    public DbSet<AppointmentPrescription> AppointmentPrescriptions { get; set; }
    public DbSet<DoctorHealthCenter> DoctorHealthCenters { get; set; }
    public DbSet<DoctorMedicalSpecialty> DoctorMedicalSpecialities { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole<Guid>>(entity => { entity.ToTable("Roles"); });
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<IdentityUserRole<Guid>>(entity => { entity.ToTable("UserRoles"); });
        modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => { entity.ToTable("UserClaims"); });
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity => { entity.ToTable("RoleClaims"); });
        modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => { entity.ToTable("UserLogins"); });
        modelBuilder.Entity<IdentityUserToken<Guid>>(entity => { entity.ToTable("UserTokens"); });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id).IsUnique();
            entity.HasIndex(u => u.CardId).IsUnique();
            entity.HasIndex(u => u.PhoneNumber).IsUnique();

            entity.Property(u => u.CardId).IsRequired().HasMaxLength(11);
            entity.Property(u => u.PhoneNumber).IsRequired();

            entity.Property(u => u.Sex)
                .HasConversion(
                    v => v.ToString(),
                    v => (SexEnum)Enum.Parse(typeof(SexEnum), v))
                .HasColumnType("CHAR(1)");

            //entity.Ignore(u => u.UserName)
            //.Ignore(u => u.NormalizedUserName);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patients");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id)
                    .IsUnique();
            entity.HasOne(p => p.PrimaryCarePhysician)
                .WithMany(pa => pa.PrimaryCarePatients)
                .HasForeignKey(pa => pa.PrimaryCarePhysicianId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.MedicalConsultations)
                .WithOne(pa => pa.Patient)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Appointments)
                .WithOne(pa => pa.Patient)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Allergies)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Illnesses)
                .WithOne(pi => pi.Patient)
                .HasForeignKey(pi => pi.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Discapacities)
                .WithOne(pd => pd.Patient)
                .HasForeignKey(pd => pd.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            
            entity.HasMany(p => p.RiskFactors)
                .WithOne(pr => pr.Patient)
                .HasForeignKey(pr => pr.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Medications)
                .WithOne(fh => fh.Patient)
                .HasForeignKey(fh => fh.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.HealthInsurances)
                .WithOne(fh => fh.Patient)
                .HasForeignKey(fh => fh.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.LabTests)
                .WithOne(pv => pv.Patient)
                .HasForeignKey(pv => pv.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.FamilyHistories)
                .WithOne(fh => fh.Patient)
                .HasForeignKey(fh => fh.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(p => p.Vaccines)
                .WithOne(fh => fh.Patient)
                .HasForeignKey(fh => fh.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(p => p.Height).HasColumnType("decimal(5, 2)");
            entity.Property(p => p.Weight).HasColumnType("decimal(5, 2)");

            //entity.HasQueryFilter(d => !d.Status);
            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<Patient>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctors");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id)
                    .IsUnique();

            

            entity.HasMany(k => k.Appointments)
                .WithOne(k => k.Doctor)
                .HasForeignKey(k => k.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(k => k.CurrentlyWorkingHealthCenter)
                .WithMany(k => k.Doctors)
                .HasForeignKey(k => k.CurrentlyWorkingHealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Specialties)
               .WithOne(k => k.Doctor)
               .HasForeignKey(k => k.DoctorId)
               .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.MedicalConsultations)
              .WithOne(k => k.Doctor)
              .HasForeignKey(k => k.DoctorId)
              .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.PrimaryCarePatients)
              .WithOne(k => k.PrimaryCarePhysician)
              .HasForeignKey(k => k.PrimaryCarePhysicianId)
              .OnDelete(DeleteBehavior.NoAction);
            //entity.HasQueryFilter(d => !d.Status);
            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.Id)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admins");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id)
                    .IsUnique();
            entity.HasOne(a=>a.HealthCenter)
            .WithMany(h=>h.Admins)
            .HasForeignKey(e=>e.HealthCenterId)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Assistant>(entity =>
        {
            entity.ToTable("Assistants");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id)
                    .IsUnique();
            entity.HasOne(a => a.HealthCenter)
                .WithMany(h => h.Assistants)
                .HasForeignKey(e => e.HealthCenterId)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<Assistant>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasQueryFilter(d => !d.IsDeleted);
        });

        modelBuilder.Entity<PatientAllergy>(entity =>
        {
            entity.ToTable("PatientAllergies");
            entity.HasKey(pa => new { pa.PatientId, pa.AllergyId });
            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Allergies)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.Allergy)
                .WithMany(a => a.PatientAllergies)
                .HasForeignKey(pa => pa.AllergyId);
            entity.Property(pa => pa.DiagnosisDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.ToTable("Allergies");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Title)
                .IsRequired();

            entity.Property(a => a.Description)
                .IsRequired();

            entity.Property(a => a.IcdCode)
                .IsRequired();

            entity.HasMany(a => a.PatientAllergies)
                .WithOne(pa => pa.Allergy)
                .HasForeignKey(pa => pa.AllergyId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(a => a.PatientId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.HealthCenter)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.HealthCenterId)
                   .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a=>a.MedicalConsultation)
                .WithMany(a=> a.Appointments)
                .HasForeignKey(a=>a.MedicalConsultationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AppointmentPrescription>(entity =>
        {
            entity.ToTable("AppointmentPrescriptions");
            entity.HasKey(ap => ap.Id);

            entity.HasOne(ap => ap.ClinicalHistory)
            .WithMany()
            .HasForeignKey(ap => ap.MedicalconsultationId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(ap => ap.Appointment)
            .WithMany()
            .HasForeignKey(ap => ap.AppointmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(ap => ap.Prescription)
            .WithMany(p => p.PrescribedAppointments)
            .HasForeignKey(ap => ap.PrescriptionId)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<HealthCenter>(entity =>
        {
            entity.ToTable("HealthCenters");
            entity.HasKey(a => a.Id);

            entity.HasMany(k => k.Appointments)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Doctors)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Admins)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Assistants)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Services)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);
        });


        modelBuilder.Entity<HealthCenterServices>(entity =>
        {
            entity.ToTable("HealthCenterServices");
            entity.HasKey(a => a.Id);

            // ...
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Locations");
            entity.HasKey(a => a.Id);

            entity.Property(l => l.Latitude)
                    .HasColumnType("decimal(10, 8)");

            entity.Property(l => l.Longitude)
                    .HasColumnType("decimal(11, 8)");
        });

        modelBuilder.Entity<MedicalConsultation>(entity =>
        {
            entity.ToTable("ClinicalHistories");
            entity.HasKey(a => a.Id);

            entity
                .HasOne(k => k.Prescription)
                .WithOne(k => k.ClinicalHistory)
                .HasForeignKey<MedicalConsultation>(k => k.PrescriptionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasQueryFilter(d => d.IsActive);
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.ToTable("FamilyHistories");
            entity.HasKey(a => a.Id);

            // ...

            entity.HasQueryFilter(d => !d.IsDeleted);
        });

        modelBuilder.Entity<Discapacity>(entity =>
        {
            entity.ToTable("Discapacities");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Type).IsRequired();

            entity.HasMany(a => a.PatientDiscapacities)
                .WithOne(pa => pa.Discapacity)
                .HasForeignKey(pa => pa.DiscapacityId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PatientDiscapacity>(entity =>
        {
            entity.ToTable("PatientDiscapacities");
            entity.HasKey(pa => new { pa.PatientId, pa.DiscapacityId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Discapacities)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.Discapacity)
                .WithMany(a => a.PatientDiscapacities)
                .HasForeignKey(pa => pa.DiscapacityId);
            entity.Property(pa => pa.DiagnosisDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<Illness>(entity =>
        {
            entity.ToTable("Illnesses");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.CodeType).IsRequired();
            entity.Property(a => a.Title).IsRequired();
            entity.Property(a => a.IcdCode).IsRequired();

            entity.HasMany(a => a.PatientIllnesses)
                .WithOne(pa => pa.Illness)
                .HasForeignKey(pa => pa.IllnessId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PatientIllness>(entity =>
        {
            entity.ToTable("PatientIllnesses");
            entity.HasKey(pa => new { pa.PatientId, pa.IllnessId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Illnesses)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.Illness)
                .WithMany(a => a.PatientIllnesses)
                .HasForeignKey(pa => pa.IllnessId);
            entity.Property(pa => pa.DischargeDate)
                .HasColumnType("Date");
            entity.Property(pa => pa.DiagnosisDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<RiskFactor>(entity =>
        {
            entity.ToTable("RiskFactors");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.CodeType).IsRequired();
            entity.Property(a => a.AssessmentLevel).IsRequired();
            entity.Property(a => a.IcdCode).IsRequired();
            entity.Property(a => a.Category).IsRequired();

            entity.HasMany(a => a.PatientRiskFactors)
                .WithOne(pa => pa.RiskFactor)
                .HasForeignKey(pa => pa.RiskFactorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PatientRiskFactor>(entity =>
        {
            entity.ToTable("PatientRiskFactors");
            entity.HasKey(pa => new { pa.PatientId, pa.RiskFactorId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.RiskFactors)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.RiskFactor)
                .WithMany(a => a.PatientRiskFactors)
                .HasForeignKey(pa => pa.RiskFactorId);
            entity.Property(pa => pa.DiagnosisDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<PatientVaccine>(entity =>
        {
            entity.ToTable("PatientVaccines");
            entity.HasKey(pa => new { pa.PatientId, pa.VaccineId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Vaccines)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.Vaccine)
                .WithMany(a => a.PatientVaccines)
                .HasForeignKey(pa => pa.VaccineId);
            entity.Property(pa => pa.AppliedDoses);
            entity.Property(pa => pa.LastApplicationDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.ToTable("Vaccines");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Disease)
                .IsRequired();

            entity.Property(a => a.Doses)
                .IsRequired();

            entity.Property(a => a.Laboratory)
                .IsRequired();

            entity.HasMany(a => a.PatientVaccines)
                .WithOne(pa => pa.Vaccine)
                .HasForeignKey(pa => pa.VaccineId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.ToTable("HealthInsurances");
            entity.HasKey(a => a.Id);

            // ...
        });

        modelBuilder.Entity<MedicationCoverage>(entity =>
        {
            entity.ToTable("MedicationCoverages");
            entity.HasKey(a => a.Id);

            // ...
        });

        modelBuilder.Entity<MedicationPrescription>(entity =>
        {
            entity.ToTable("MedicationPrescriptions");
            entity.HasKey(a => a.Id);

            // ...
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.ToTable("Prescriptions");
            entity.HasKey(a => a.Id);

            entity
                .HasMany(k => k.PrescribedMedications)
                .WithOne(k => k.Prescription)
                .HasForeignKey(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.PrescribedAppointments)
                .WithOne(k => k.Prescription)
                .HasForeignKey(k => k.PrescriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.MedicalConsultation)
                    .WithOne(k => k.Prescription)
                    .HasForeignKey<Prescription>(k => k.ClinicalHistoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medications");
            entity.HasKey(a => a.Id);

            entity.Property(m => m.Concentration)
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.ToTable("LabTests");
            entity.HasKey(a => a.Id);
        });

        modelBuilder.Entity<MedicationCoverage>(entity =>
        {
            entity.Property(mc => mc.CopayAmount)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            entity.Property(mc => mc.CoinsurancePercentage)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();
        });

        modelBuilder.Entity<DoctorHealthCenter>(entity =>
        {
            entity.ToTable("DoctorHealthCenters");
            entity.HasKey(a => a.Id);

            entity.HasOne(pa => pa.Doctor)
                            .WithMany(p => p.CurrentlyWorkingHealthCenters)
                            .HasForeignKey(pa => pa.DoctorId)
                            .IsRequired(false);
            entity.HasOne(pa => pa.HealthCenter)
                .WithMany(a => a.Doctors)
                .HasForeignKey(pa => pa.HealthCenterId);

            entity.Property(e => e.EntryHour)
                .HasConversion(
                    v => TimeSpanToString(v),
                    v => StringToTimeSpan(v)
                );

            entity.Property(e => e.ExitHour)
            .HasConversion(
                v => TimeSpanToString(v),
                v => StringToTimeSpan(v)
            );
        });

        modelBuilder.Entity<MedicalSpecialty>(entity =>
        {
            entity.ToTable("MedicalSpecialities");
            entity.HasKey(a => a.Id);

            // ...
        });

        modelBuilder.Entity<DoctorMedicalSpecialty>(entity =>
        {
            entity.ToTable("DoctorMedicalSpecialities");
            entity.HasKey(a => a.Id);

            entity.HasOne(pa => pa.Doctor)
                .WithMany(p => p.Specialties)
                .HasForeignKey(pa => pa.DoctorId)
                .IsRequired(false);
            entity.HasOne(pa => pa.MedicalSpecialty)
                .WithMany(a => a.Doctors)
                .HasForeignKey(pa => pa.MedicalSpecialtyId);

            // ...
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.ToTable("HealthInsurances");
            entity.HasKey(a => a.Id);

            entity.HasMany(k => k.MedicationCoverages)
                .WithOne(k => k.HealthInsurance)
                .HasForeignKey(k => k.HealthInsuranceId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(k => k.SubscribedPatients)
                .WithOne(k => k.HealthInsurance)
                .HasForeignKey(k => k.HealthInsuranceId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PatientHealthInsurance>(entity =>
        {
            entity.ToTable("PatientHealthInsurances");
            entity.HasKey(pa => new { pa.PatientId, pa.HealthInsuranceId });
            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.HealthInsurances)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired(false);
            entity.HasOne(pa => pa.HealthInsurance)
                .WithMany(a => a.SubscribedPatients)
                .HasForeignKey(pa => pa.HealthInsuranceId);
            entity.Property(pa => pa.PolicyNumber)
                .IsRequired();
        });

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new AssistantConfiguration());

        // Configuraciones relacionadas con el paciente y sus atributos
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

        // Configuraciones relacionadas con citas y servicios médicos
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new HealthCenterConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalSpecialtyConfiguration());

        modelBuilder.ApplyConfiguration(new DoctorHealthCenterConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorMedicalSpecialtyConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentPrescriptionConfiguration());

        // Configuraciones de entidades secundarias y auxiliares
        modelBuilder.ApplyConfiguration(new HealthInsuranceConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new AllergyConfiguration());
        modelBuilder.ApplyConfiguration(new IllnessConfiguration());
        modelBuilder.ApplyConfiguration(new DiscapacityConfiguration());
        modelBuilder.ApplyConfiguration(new RiskFactorConfiguration());
        modelBuilder.ApplyConfiguration(new VaccineConfiguration());

        // Configuraciones de laboratorios y medicamentos
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationCoverageConfiguration());
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

        return TimeSpan.Zero;
    }
}
