public sealed class TransactionFailedException : Exception
{
    public TransactionFailedException(string message)
        : base(message)
    {
    }
}