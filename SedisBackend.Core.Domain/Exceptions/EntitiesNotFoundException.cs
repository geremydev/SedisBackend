namespace SedisBackend.Core.Domain.Exceptions;

public sealed class EntitiesNotFoundException : NotFoundException
{
    public EntitiesNotFoundException()
        : base($"There are no entities in this table.")
    {
    }
}
