namespace StripsBL.Exceptions;

public class ReeksException : Exception
{
    public ReeksException(string? message) : base(message)
    {
    }

    public ReeksException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}