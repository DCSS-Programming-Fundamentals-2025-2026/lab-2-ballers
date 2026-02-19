using lab1_ballers.Domain.Cards;
using lab1_ballers.Upgrade;
using System.Collections;

namespace lab1_ballers.Domain.CardsRepos;

public class CardRepository : IEnumerable
{
    public CardBase[] cards = new CardBase[200];
    public int counter = 0;

    public void AddCard(CardBase card)
    {
        if (counter < cards.Length)
        {
            cards[counter] = card;
            counter++;
        }
    }

    public CardBase GetCard(int index)
    {
        if (index >= 0 && index < counter)
            return cards[index];

        return null;
    }

    public CardBase[] GetCards(object typeCard)
    {
        int count = 0;
        for (int i = 0; i < counter; i++)
        {
            if (typeCard == null || cards[i].Type.Equals(typeCard))
                count++;
        }

        CardBase[] returnCards = new CardBase[count];
        int index = 0;

        for (int i = 0; i < counter; i++)
        {
            if (typeCard == null || cards[i].Type.Equals(typeCard))
            {
                returnCards[index] = cards[i];
                index++;
            }
        }

        return returnCards;
    }

    public void DeleteCard(int index)
    {
        if (index < 0 || index >= counter)
            throw new IndexOutOfRangeException("Index out of range");

        for (int i = index; i < counter - 1; i++)
            cards[i] = cards[i + 1];

        counter--;
        cards[counter] = null;
    }

    public IEnumerator GetEnumerator()
    {
        return new CardEnumerator(cards);
    }

    public void NaturalSort()
    {
        Array.Sort(cards, 0, counter);
    }

    public void AlternativeSort()
    {
        Array.Sort (cards, 0, counter, new CardComparer());
        Array.Reverse(cards);
    }
}
