namespace StripsBL.Exceptions;

public class UitgeverijException : Exception
{
    public UitgeverijException(string? message) : base(message)
    {
    }

    public UitgeverijException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}