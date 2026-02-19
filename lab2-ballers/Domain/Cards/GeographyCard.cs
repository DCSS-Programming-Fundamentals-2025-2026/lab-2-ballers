using lab1_ballers.Domain.Enums;

namespace lab1_ballers.Domain.Cards;

public class GeographyCard : CardBase
{
    public GeographyCard(string question, string answer) : base(question, answer)
    {
        Type = CardType.Geography;
    }
    
    public override string ToString()
    {
        return $" Type: {Type} ||  Question: {Question} ||  Answer: {Answer}";
    }
}