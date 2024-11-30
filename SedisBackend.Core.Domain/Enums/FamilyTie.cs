namespace SedisBackend.Core.Domain.Enums;

public enum FamilyTie
{
    // Parentesco biológico
    Mother = 1,
    Father,
    Son,
    Daughter,

    // Abuelos
    Grandmother,
    Grandfather,

    // Hermanos
    Brother,
    Sister,

    // Tíos y tías
    Uncle,
    Aunt,

    // Primos y primas
    Cousin,

    // Otros
    Spouse, // Cónyuge
    Partner, // Pareja
    Guardian, // Tutor legal
    StepParent, // Padrastro o madrastra
    StepChild, // Hijo o hijastra
    InLaw, // Pariente político
    SiblingInLaw, // Cuñado o cuñada
    Niece, // Sobrina
    Nephew, // Sobrino
    Godparent, // Padrino o madrina
    FosterParent, // Padre o madre adoptivo/a
    FosterChild // Hijo o hija adoptivo/a
}
