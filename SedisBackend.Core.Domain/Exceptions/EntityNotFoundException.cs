namespace SedisBackend.Core.Domain.Exceptions;

public sealed class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(Guid entityId)
        : base($"The entity with id: {entityId} doesn't exist in the database.")
    {
    }
}
