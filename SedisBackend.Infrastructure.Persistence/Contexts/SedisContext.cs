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
    public DbSet<MedicalConsultation> MedicalConsultations { get; set; }
    public DbSet<FamilyHistory> FamilyHistories { get; set; }
    public DbSet<Discapacity> Discapacities { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<LabTech> LabTechs { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MedicalSpecialty> MedicalSpecialities { get; set; }
    public DbSet<Illness> Illnesses { get; set; }
    public DbSet<RiskFactor> RiskFactors { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<HealthInsurance> HealthInsurances { get; set; }
    public DbSet<MedicationCoverage> MedicationCoverages { get; set; }
    public DbSet<PatientDiscapacity> PatientDiscapacities { get; set; }
    public DbSet<PatientIllness> PatientIllnesses { get; set; }
    public DbSet<PatientRiskFactor> PatientRiskFactors { get; set; }
    public DbSet<PatientVaccine> PatientVaccines { get; set; }
    public DbSet<PatientHealthInsurance> PatientHealthInsurances { get; set; }
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
                .OnDelete(DeleteBehavior.NoAction);
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
            entity.HasOne(a => a.HealthCenter)
            .WithMany(h => h.Admins)
            .HasForeignKey(e => e.HealthCenterId)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<LabTech>(entity =>
        {
            entity.ToTable("LabTechs");

            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id)
                    .IsUnique();
            entity.HasOne(p => p.ApplicationUser)
                .WithOne()
                .HasForeignKey<LabTech>(d => d.Id)
                .OnDelete(DeleteBehavior.NoAction);
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

            //entity.HasQueryFilter(d => !d.IsDeleted);
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
            entity.HasOne(pa => pa.MedicalConsultation)
                .WithMany(a => a.Allergies)
                .HasForeignKey(pa => pa.AllergyId)
                .IsRequired(false);
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
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            entity.HasOne(a => a.MedicalConsultation)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.MedicalConsultationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.Doctor)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .IsRequired();
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
                    .WithOne(k => k.CurrentlyWorkingHealthCenter)
                    .HasForeignKey(k => k.CurrentlyWorkingHealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Admins)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(k => k.Assistants)
                    .WithOne(k => k.HealthCenter)
                    .HasForeignKey(k => k.HealthCenterId)
                    .OnDelete(DeleteBehavior.NoAction);
        });


        modelBuilder.Entity<HealthCenterServices>(entity =>
        {
            entity.ToTable("HealthCenterServices");
            entity.HasKey(a => a.Id);


            entity.HasOne(hcs => hcs.HealthCenter)
                .WithMany(hc => hc.HealthCenterServices)
                .HasForeignKey(hcs => hcs.HealthCenterId);

            entity.HasOne(hcs => hcs.Service)
                .WithMany(s => s.HealthCenterServices)
                .HasForeignKey(hcs => hcs.ServiceId);
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

            modelBuilder.Entity<MedicalConsultation>()
                 .HasOne(mc => mc.Patient)
                 .WithMany(p => p.MedicalConsultations)
                 .HasForeignKey(mc => mc.PatientId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalConsultation>()
                .HasOne(mc => mc.Doctor)
                .WithMany(d => d.MedicalConsultations)
                .HasForeignKey(mc => mc.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.Appointments)
                .WithOne(a => a.MedicalConsultation)
                .HasForeignKey(a => a.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.Allergies)
                .WithOne(a => a.MedicalConsultation)
                .HasForeignKey(a => a.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.Discapacities)
                .WithOne(d => d.MedicalConsultation)
                .HasForeignKey(d => d.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.Illnesses)
                .WithOne(i => i.MedicalConsultation)
                .HasForeignKey(i => i.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.RiskFactors)
                .WithOne(rf => rf.MedicalConsultation)
                .HasForeignKey(rf => rf.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.PatientMedications)
                .WithOne(pm => pm.MedicalConsultation)
                .HasForeignKey(pm => pm.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicalConsultation>()
                .HasMany(mc => mc.PatientLabTests)
                .WithOne(plt => plt.MedicalConsultation)
                .HasForeignKey(plt => plt.MedicalConsultationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //entity.HasQueryFilter(d => d.IsActive);
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.ToTable("FamilyHistories");
            entity.HasKey(a => a.Id);

            modelBuilder.Entity<FamilyHistory>()
                .HasOne(fh => fh.Patient)
                .WithMany(p => p.FamilyHistories)
                .HasForeignKey(fh => fh.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FamilyHistory>()
                .HasOne(fh => fh.Relative)
                .WithMany()
                .HasForeignKey(fh => fh.RelativeId)
                .OnDelete(DeleteBehavior.NoAction);

            //entity.HasQueryFilter(d => !d.IsDeleted);
        });

        modelBuilder.Entity<Discapacity>(entity =>
        {
            entity.ToTable("Discapacities");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.IcdCode).IsRequired();

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
            entity.HasOne(pa => pa.MedicalConsultation)
                .WithMany(a => a.Discapacities)
                .HasForeignKey(pa => pa.DiscapacityId);
        });

        modelBuilder.Entity<Illness>(entity =>
        {
            entity.ToTable("Illnesses");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.IcdCode).IsRequired();
            entity.Property(a => a.Title).IsRequired();
            entity.Property(a => a.IcdCode).IsRequired();

            entity.HasMany(a => a.PatientIllnesses)
                .WithOne(pa => pa.Illness)
                .HasForeignKey(pa => pa.IllnessId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // Brahiam...

        modelBuilder.Entity<PatientIllness>(entity =>
        {
            entity.ToTable("PatientIllnesses");
            entity.HasKey(pa => new { pa.PatientId, pa.IllnessId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Illnesses)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired();

            entity.HasOne(pa => pa.Illness)
                .WithMany(a => a.PatientIllnesses)
                .HasForeignKey(pa => pa.IllnessId);

            entity.HasOne(pa => pa.MedicalConsultation)
                .WithMany(a => a.Illnesses)
                .HasForeignKey(pa => pa.IllnessId)
                .IsRequired(false);

            entity.Property(pi => pi.DocumentURL).HasMaxLength(2048);
            entity.Property(pi => pi.Status).HasMaxLength(50).HasDefaultValue("Activo").IsRequired();
            entity.Property(pi => pi.Notes);

            entity.Property(pa => pa.DiagnosisDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            entity.Property(pa => pa.DischargeDate)
                .HasColumnType("Date");
        });

        modelBuilder.Entity<RiskFactor>(entity =>
        {
            entity.ToTable("RiskFactors");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.IcdCode).IsRequired();
            entity.Property(a => a.Title).IsRequired();
            entity.Property(a => a.IcdCode).IsRequired();
            entity.Property(a => a.Description).IsRequired();

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
                .IsRequired();

            entity.HasOne(pa => pa.RiskFactor)
                .WithMany(a => a.PatientRiskFactors)
                .HasForeignKey(pa => pa.RiskFactorId);

            entity.HasOne(pa => pa.MedicalConsultation)
                .WithMany(a => a.RiskFactors)
                .HasForeignKey(pa => pa.RiskFactorId);

            entity.Property(pa => pa.DiagnosisDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(pi => pi.Status).HasMaxLength(50).HasDefaultValueSql("Activo").IsRequired();
        });

        modelBuilder.Entity<PatientVaccine>(entity =>
        {
            entity.ToTable("PatientVaccines");
            entity.HasKey(pa => new { pa.PatientId, pa.VaccineId });

            entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.Vaccines)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired();

            entity.HasOne(pa => pa.Vaccine)
                .WithMany(a => a.PatientVaccines)
                .HasForeignKey(pa => pa.VaccineId);

            entity.Property(pa => pa.AppliedDoses).IsRequired();

            entity.Property(pa => pa.LastApplicationDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(pi => pi.Status).HasMaxLength(50).HasDefaultValue(false).IsRequired();
        });

        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.ToTable("Vaccines");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired();

            entity.Property(a => a.Doses)
                .IsRequired();

            entity.Property(a => a.Laboratory)
                .IsRequired();

            entity.HasMany(a => a.PatientVaccines)
                .WithOne(pa => pa.Vaccine)
                .HasForeignKey(pa => pa.VaccineId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.ToTable("HealthInsurances");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.InsuranceName)
                .IsRequired();

            entity.Property(a => a.PolicyType)
                .IsRequired();

            entity.Property(a => a.InsuranceCompany)
                .IsRequired();

            entity.Property(a => a.CoverageLevel)
                .IsRequired();

            entity.HasMany(a => a.MedicationCoverages)
                .WithOne(hi => hi.HealthInsurance)
                .HasForeignKey(hi => hi.HealthInsuranceId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(a => a.SubscribedPatients)
                .WithOne(hi => hi.HealthInsurance)
                .HasForeignKey(hi => hi.HealthInsuranceId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MedicationCoverage>(entity =>
        {
            entity.ToTable("MedicationCoverages");
            entity.HasKey(a => a.Id);

            entity.HasOne(mc => mc.HealthInsurance)
                .WithMany(mc => mc.MedicationCoverages)
                .HasForeignKey(mc => mc.HealthInsuranceId)
                .IsRequired();

            entity.HasOne(mc => mc.Medication).WithMany(m => m.Coverages).HasForeignKey(mc => mc.MedicationId).IsRequired();
            entity.Property(mc => mc.CoverageStatus).IsRequired();
            entity.Property(mc => mc.CopayAmount)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            entity.Property(mc => mc.CoinsurancePercentage)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();

            entity.Property(mc => mc.PriorAuthorizationRequired)
                .IsRequired();
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medications");

            entity.HasKey(m => m.Id);

            entity.Property(m => m.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(m => m.DosageForm)
                .IsRequired();

            entity.Property(m => m.ActiveIngredient)
                .HasMaxLength(500);

            entity.Property(m => m.Concentration)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            entity.Property(m => m.UnitOfMeasurement)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(m => m.RouteOfAdministration)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(m => m.Indications)
                .HasMaxLength(2000);

            entity.Property(m => m.Contraindications)
                .HasMaxLength(2000);

            entity.Property(m => m.Precautions)
                .HasMaxLength(2000);

            entity.Property(m => m.SideEffects)
                .HasMaxLength(2000);

            entity.Property(m => m.DrugInteractions)
                .HasMaxLength(2000);

            entity.Property(m => m.Presentation)
                .HasMaxLength(500);

            entity.Property(m => m.ImageUrl)
                .HasMaxLength(2048);

            entity.Property(m => m.NationalCode)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.ToTable("LabTests");

            entity.HasKey(lt => lt.Id);

            entity.Property(lt => lt.TestName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(lt => lt.TestCode)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MedicalSpecialty>(entity =>
        {
            entity.ToTable("MedicalSpecialties");

            entity.HasKey(ms => ms.Id);

            entity.Property(ms => ms.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(ms => ms.Description)
                .HasMaxLength(1000);

            entity.HasMany(ms => ms.Doctors)
                .WithOne(dms => dms.MedicalSpecialty)
                .HasForeignKey(dms => dms.MedicalSpecialtyId)
                .IsRequired();
        });

        modelBuilder.Entity<DoctorMedicalSpecialty>(entity =>
        {
            entity.ToTable("DoctorMedicalSpecialities");
            entity.HasKey(a => a.Id);

            entity.HasOne(dms => dms.Doctor)
                .WithMany(d => d.Specialties)
                .HasForeignKey(dms => dms.DoctorId)
                .IsRequired();

            entity.HasOne(dms => dms.MedicalSpecialty)
                .WithMany(ms => ms.Doctors)
                .HasForeignKey(dms => dms.MedicalSpecialtyId)
                .IsRequired();
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.ToTable("HealthInsurances");

            entity.HasKey(hi => hi.Id);

            entity.Property(hi => hi.InsuranceName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(hi => hi.PolicyType)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(hi => hi.InsuranceCompany)
                .HasMaxLength(255);

            entity.Property(hi => hi.CoverageLevel)
                .HasMaxLength(100);

            entity.HasMany(hi => hi.MedicationCoverages)
                .WithOne(mc => mc.HealthInsurance)
                .HasForeignKey(mc => mc.HealthInsuranceId);

            entity.HasMany(hi => hi.SubscribedPatients)
                .WithOne(ph => ph.HealthInsurance)
                .HasForeignKey(ph => ph.HealthInsuranceId);
        });

        modelBuilder.Entity<PatientHealthInsurance>(entity =>
        {
            entity.ToTable("PatientHealthInsurances");

            entity.HasKey(ph => new { ph.PatientId, ph.HealthInsuranceId });

            entity.Property(ph => ph.PolicyNumber)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(ph => ph.Status)
                .IsRequired();

            entity.HasOne(ph => ph.Patient)
                .WithMany(p => p.HealthInsurances)
                .HasForeignKey(ph => ph.PatientId);

            entity.HasOne(ph => ph.HealthInsurance)
                .WithMany(hi => hi.SubscribedPatients)
                .HasForeignKey(ph => ph.HealthInsuranceId);
        });

        /*modelBuilder.ApplyConfiguration(new UserConfiguration());
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
        modelBuilder.ApplyConfiguration(new MedicalConsultationConfiguration());
        *//*modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationPrescriptionConfiguration());*//*

        // Configuraciones relacionadas con citas y servicios médicos
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new HealthCenterConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalSpecialtyConfiguration());

        //modelBuilder.ApplyConfiguration(new DoctorHealthCenterConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorMedicalSpecialtyConfiguration());
        //modelBuilder.ApplyConfiguration(new PatientLabTestPrescriptionConfiguration());

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
        modelBuilder.ApplyConfiguration(new MedicationCoverageConfiguration());*/
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
