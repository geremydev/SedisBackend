namespace SedisBackend.Core.Domain.Exceptions;
public sealed class UserNotFoundException : BadRequestException
{
    public UserNotFoundException(string Id)
        : base($"The user with Id {Id} don't exists in the database.")
    {
    }
}
