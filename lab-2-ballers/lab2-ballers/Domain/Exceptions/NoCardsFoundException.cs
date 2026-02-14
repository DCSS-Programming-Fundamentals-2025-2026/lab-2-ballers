namespace lab1_ballers.Domain.Exceptions;

public class NoCardsFoundException : Exception
{
    public NoCardsFoundException() : base("⚠ No cards found"){}
    public NoCardsFoundException(string message) : base(message){}
}