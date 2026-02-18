using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.CardsRepos;
using lab1_ballers.Domain.Exceptions;

namespace lab1_ballers.App;

public class CardService
{
    private CardRepository _repository;

    public CardService(CardRepository repository)
    {
        _repository = repository;
    }

    public void AddCardByParams(int type, string question, string answer)
    {
        CardBase card = null;

        if (type == 1)
            card = new GeographyCard(question, answer);
        
        else if (type == 2)
            card = new MathCard(question, answer);
        
        else if (type == 3)
            card = new EnglishCard(question, answer);
        
        else
            throw new InvalidInputException();
        
        _repository.AddCard(card);
    }

    public void RemoveCard(int index)
    {
        _repository.DeleteCard(index);
    }
    
    public CardBase[] GetReport(object typeCard)
    {
        return _repository.GetCards(typeCard);
    }

    public CardBase GetCardById(int index)
    {
        return _repository.GetCard(index);
    }
   
}