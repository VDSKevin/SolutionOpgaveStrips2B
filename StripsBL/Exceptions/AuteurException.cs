namespace StripsBL.Exceptions;

public class AuteurException : Exception
{
    public AuteurException(string? message) : base(message)
    {
    }

    public AuteurException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}