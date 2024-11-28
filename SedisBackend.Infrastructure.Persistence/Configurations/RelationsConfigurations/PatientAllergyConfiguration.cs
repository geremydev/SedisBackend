﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Infrastructure.Persistence.Configurations.RelationsConfigurations;

public class PatientAllergyConfiguration : IEntityTypeConfiguration<PatientAllergy>
{
    public void Configure(EntityTypeBuilder<PatientAllergy> builder)
    {
        builder.HasData
        (
            new PatientAllergy
            {
                PatientId = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                AllergyId = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"),
                Allergen = "Polen",
                AllergicReaction = "Congestión nasal y estornudos",
                DiagnosisDate = DateTime.Parse("2022-03-12"),
                Description = "Reacción alérgica leve al polen durante la primavera.",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                AllergyId = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"),
                Allergen = "Maní",
                AllergicReaction = "Dificultad para respirar y urticaria",
                DiagnosisDate = DateTime.Parse("2020-10-05"),
                Description = "Reacción severa a la exposición al maní.",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                AllergyId = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"),
                Allergen = "Ácaros del polvo",
                AllergicReaction = "Estornudos frecuentes y congestión nasal",
                DiagnosisDate = DateTime.Parse("2021-06-18"),
                Description = "Reacción moderada al polvo en casa.",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                AllergyId = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"),
                Allergen = "Lácteos",
                AllergicReaction = "Dolor abdominal y náuseas",
                DiagnosisDate = DateTime.Parse("2019-08-21"),
                Description = "Reacción leve a productos lácteos.",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                AllergyId = Guid.Parse("33c7785e-58f4-4ab8-9f54-51bf8978963f"),
                Allergen = "Polen de flores",
                AllergicReaction = "Picazón en los ojos y congestión nasal",
                DiagnosisDate = DateTime.Parse("2021-04-15"),
                Description = "Reacción alérgica durante la primavera.",
                Status = true
            },
            new PatientAllergy
            {
                PatientId = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                AllergyId = Guid.Parse("b0fa92b6-1a21-4e9e-845e-e2d5bbfe5e1d"),
                Allergen = "Gluten",
                AllergicReaction = "Diarrea y fatiga",
                DiagnosisDate = DateTime.Parse("2020-02-11"),
                Description = "Reacción leve a alimentos con gluten.",
                Status = true
            }
        );
    }
}
