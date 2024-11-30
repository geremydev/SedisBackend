namespace SedisBackend.Core.Domain.Exceptions;

public sealed class PatchRequestException : BadRequestException
{
    public PatchRequestException(string error)
        : base($"Error applying patch: {error}")
    {
    }
}
