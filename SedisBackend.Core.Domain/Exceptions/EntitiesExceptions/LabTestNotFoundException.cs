namespace SedisBackend.Core.Domain.Exceptions.EntitiesExceptions;

public sealed class LabTestNotFoundException : NotFoundException
{
    public LabTestNotFoundException(Guid labTestId)
        : base($"The laboratory test with id: {labTestId} doesn't exist in the database.")
    {
    }
}
