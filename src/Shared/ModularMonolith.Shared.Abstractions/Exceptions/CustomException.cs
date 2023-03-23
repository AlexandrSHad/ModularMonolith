namespace ModularMonolith.Shared.Abstractions.Exceptions;

public class CustomException : Exception // I would call this Application exception
{
    public CustomException(string message) : base(message)
    {
    }
}