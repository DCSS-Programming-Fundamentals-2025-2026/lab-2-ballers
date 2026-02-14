using lab1_ballers.Domain.Enums;

namespace lab1_ballers.Domain.Cards;

public abstract class CardBase
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public CardType Type { get; set; }
    
    public CardBase()
    {
        
    }
    
    public CardBase(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public override string ToString()
    {
        return $"Type: {Type} ||  Question: {Question} ||  Answer: {Answer}";
    }
}