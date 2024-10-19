namespace SedisBackend.Core.Domain.Exceptions.EntitiesExceptions;
public sealed class LabTestsNotFoundException : NotFoundException
{
    public LabTestsNotFoundException()
        : base($"The are no laboratoy tests in the database.")
    {
    }
}
