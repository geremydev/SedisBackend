﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasData
        (
            new Medication
            {
                Id = Guid.Parse("a2d1c5b7-8f4e-4a6b-9c3d-5e7a1b2c9f5d"),
                Name = "Metformina",
                DosageForm = DosageForm.Tablet.ToString(),
                ActiveIngredient = "Metformina",
                Concentration = 500,
                UnitOfMeasurement = "mg",
                RouteOfAdministration = "Oral",
                Indications = "Tratamiento de la diabetes tipo 2.",
                Contraindications = "Insuficiencia renal severa, cetoacidosis diabética.",
                Precautions = "Controlar función renal periódicamente.",
                SideEffects = "Náuseas, vómitos, diarrea, dolor abdominal.",
                DrugInteractions = "Mayor riesgo de acidosis láctica con alcohol.",
                Presentation = "Caja con 30 tabletas de 500 mg.",
                ImageUrl = "http://example.com/metformina.jpg",
                NationalCode = "M500",
                Status = true
            },
            new Medication
            {
                Id = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                Name = "Atorvastatina",
                DosageForm = DosageForm.Tablet.ToString(),
                ActiveIngredient = "Atorvastatina",
                Concentration = 20,
                UnitOfMeasurement = "mg",
                RouteOfAdministration = "Oral",
                Indications = "Reducción de niveles elevados de colesterol y triglicéridos.",
                Contraindications = "Hipersensibilidad al principio activo, enfermedad hepática activa.",
                Precautions = "Controlar función hepática periódicamente.",
                SideEffects = "Dolor muscular, elevación de enzimas hepáticas.",
                DrugInteractions = "Mayor riesgo de miopatía con gemfibrozil o ciclosporina.",
                Presentation = "Caja con 30 tabletas de 20 mg.",
                ImageUrl = "http://example.com/atorvastatina.jpg",
                NationalCode = "A020",
                Status = true
            },
            new Medication
            {
                Id = Guid.Parse("c3f4a6b7-8d1e-4b9c-2e7a-1c5b3d6f9e7a"),
                Name = "Ibuprofeno",
                DosageForm = DosageForm.Tablet.ToString(),
                ActiveIngredient = "Ibuprofeno",
                Concentration = 400,
                UnitOfMeasurement = "mg",
                RouteOfAdministration = "Oral",
                Indications = "Alivio de dolor leve a moderado, fiebre.",
                Contraindications = "Úlcera péptica activa, insuficiencia renal severa.",
                Precautions = "Usar con precaución en pacientes con antecedentes de sangrado gastrointestinal.",
                SideEffects = "Náuseas, dispepsia, riesgo de sangrado gastrointestinal.",
                DrugInteractions = "Disminuye el efecto de los antihipertensivos.",
                Presentation = "Caja con 20 tabletas de 400 mg.",
                ImageUrl = "http://example.com/ibuprofeno.jpg",
                NationalCode = "I400",
                Status = true
            },
            new Medication
            {
                Id = Guid.Parse("f6b9a1c5-2e7a-3d6f-8d1e-4b3c7f9e7a1c"),
                Name = "Amoxicilina",
                DosageForm = DosageForm.Capsule.ToString(),
                ActiveIngredient = "Amoxicilina",
                Concentration = 500,
                UnitOfMeasurement = "mg",
                RouteOfAdministration = "Oral",
                Indications = "Tratamiento de infecciones bacterianas como faringitis y otitis media.",
                Contraindications = "Hipersensibilidad a penicilinas.",
                Precautions = "Usar con precaución en pacientes con antecedentes de reacciones alérgicas.",
                SideEffects = "Erupciones cutáneas, diarrea, náuseas.",
                DrugInteractions = "Disminuye la eficacia de anticonceptivos orales.",
                Presentation = "Caja con 12 cápsulas de 500 mg.",
                ImageUrl = "http://example.com/amoxicilina.jpg",
                NationalCode = "A500",
                Status = true
            },
            new Medication
            {
                Id = Guid.Parse("d7e1c5b3-8f4a-4b6c-9f9e-2a7a1d6f8e9a"),
                Name = "Paracetamol",
                DosageForm = DosageForm.Syrup.ToString(),
                ActiveIngredient = "Paracetamol",
                Concentration = 120,
                UnitOfMeasurement = "mg/5mL",
                RouteOfAdministration = "Oral",
                Indications = "Alivio de fiebre y dolor leve a moderado.",
                Contraindications = "Insuficiencia hepática severa.",
                Precautions = "Evitar dosis superiores a las recomendadas.",
                SideEffects = "Raro: reacciones alérgicas, daño hepático en sobredosis.",
                DrugInteractions = "Aumenta el riesgo de toxicidad hepática con alcohol.",
                Presentation = "Frasco de 120 mL con 120 mg/5mL.",
                ImageUrl = "http://example.com/paracetamol.jpg",
                NationalCode = "P120",
                Status = true
            }
        );
    }
}
