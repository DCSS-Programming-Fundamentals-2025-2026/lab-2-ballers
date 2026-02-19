using lab1_ballers.Domain.Enums;
using System.Xml.Linq;

namespace lab1_ballers.Domain.Cards;

public abstract class CardBase : IComparable
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

    public int CompareTo(object? obj)
    {
        if (obj == null || obj is not CardBase other)
        {
            throw new ArgumentNullException("Invalid object.");
        }

        return string.Compare(Type.ToString(), other.Type.ToString(), StringComparison.OrdinalIgnoreCase);
    }
}