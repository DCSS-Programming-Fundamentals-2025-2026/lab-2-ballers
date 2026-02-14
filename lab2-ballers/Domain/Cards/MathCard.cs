using lab1_ballers.Domain.Enums;

namespace lab1_ballers.Domain.Cards;

public class MathCard : CardBase
{
    public MathCard(string question, string answer) : base(question, answer)
    {
        Type = CardType.Math;
    }
    
    public override string ToString()
    {
        return $" Type: {nameof(Type)} ||  Question: {Question} ||  Answer: {Answer}";
    }
}