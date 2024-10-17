﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
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
                    DosageForm = "Tablet",
                    ActiveIngredient = "Metformina",
                    Concentration = 500,
                    UnitOfMeasurement = "mg",
                    RouteOfAdministration = "Oral",
                    Indications = "Tratamiento de diabetes tipo 2",
                    Contraindications = "Insuficiencia renal",
                    Precautions = "Controlar niveles de glucosa",
                    SideEffects = "Náuseas, vómitos",
                    DrugInteractions = "No usar con insulina",
                    Presentation = "Tabletas en frasco",
                    ImageUrl = "http://example.com/image1.jpg",
                    NationalCode = "M500"
                },
                new Medication
                {
                    Id = Guid.Parse("e6b5a3c7-9d4f-4a8b-7e1c-2d9f1a5b3c6d"),
                    Name = "Atorvastatina",
                    DosageForm = "Tablet",
                    ActiveIngredient = "Atorvastatina",
                    Concentration = 20,
                    UnitOfMeasurement = "mg",
                    RouteOfAdministration = "Oral",
                    Indications = "Reducción de colesterol",
                    Contraindications = "Enfermedad hepática",
                    Precautions = "Controlar niveles de lípidos",
                    SideEffects = "Dolor muscular",
                    DrugInteractions = "No usar con ciertos antibióticos",
                    Presentation = "Tabletas en caja",
                    ImageUrl = "http://example.com/image2.jpg",
                    NationalCode = "A020"
                }
            );
        }
    }
}
