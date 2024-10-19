namespace SedisBackend.Core.Domain.Exceptions.EntitiesExceptions;

public sealed class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(Guid entityId)
        : base($"The entity with id: {entityId} doesn't exist in the database.")
    {
    }
}
