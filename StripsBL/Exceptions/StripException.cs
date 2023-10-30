namespace StripsBL.Exceptions;

public class StripException : Exception
{
    public StripException(string? message) : base(message)
    {
    }

    public StripException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}