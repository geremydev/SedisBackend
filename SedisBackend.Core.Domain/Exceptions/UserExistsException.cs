namespace SedisBackend.Core.Domain.Exceptions;

public sealed class UserExistsException : BadRequestException
{
    public UserExistsException(string entityCardId)
        : base($"The entity with card id {entityCardId} already exists in the database.")
    {
    }
}
