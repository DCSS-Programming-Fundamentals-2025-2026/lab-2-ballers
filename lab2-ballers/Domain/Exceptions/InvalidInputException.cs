namespace lab1_ballers.Domain.Exceptions;

public class InvalidInputException : Exception
{
    public InvalidInputException() : base("⚠ Invalid input, please choose an existing option"){}
    public InvalidInputException(string message) : base(message){}
}