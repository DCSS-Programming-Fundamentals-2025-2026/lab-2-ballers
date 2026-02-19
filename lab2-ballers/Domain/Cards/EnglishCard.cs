using lab1_ballers.Domain.Enums;

namespace lab1_ballers.Domain.Cards;

public class EnglishCard : CardBase
{
    public EnglishCard(string question, string answer) : base(question, answer)
    {
        Type = CardType.English;
    }
    
    public override string ToString()
    {
        return $" Type: {Type} ||  Question: {Question} ||  Answer: {Answer}";
    }
}