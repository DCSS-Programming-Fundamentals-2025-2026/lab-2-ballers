using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.CardsRepos;

namespace TestProject1;

public class Tests
{
    [Test]
    public void Test1()
    {
        CardRepository testRepository = new CardRepository();

        GeographyCard testCard = new GeographyCard("test", "testAnswer");
        
        testRepository.AddCard(testCard);
        
        

    }
}