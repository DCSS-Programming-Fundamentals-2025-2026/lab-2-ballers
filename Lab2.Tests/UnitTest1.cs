using lab1_ballers.App;
using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.CardsRepos;
using lab1_ballers.Domain.Enums;
using lab1_ballers.Domain.Exceptions;

namespace TestProject1;

[TestFixture]
public class CardRepositoryTests
{
    [Test]
    public void ValidCard_AddToRepo_Test()
    {
    
        CardRepository repo = new CardRepository();
        
        GeographyCard testCard = new GeographyCard("Capital of France?", "Paris");
        
        repo.AddCard(testCard);

        CardBase[] result = repo.GetCards(null);

        Assert.That(result.Length, Is.EqualTo(1));
        
        Assert.That(result[0].Question, Is.EqualTo("Capital of France?"));
    }

    [Test]
    public void DeleteCard_AnyCard_()
    {
        CardRepository repo = new CardRepository();
        
        GeographyCard testCard1 = new GeographyCard("Capital of France?", "Paris");
        GeographyCard testCard2 = new GeographyCard("Capital of USA?", "Washington");
        GeographyCard testCard3 = new GeographyCard("Capital of the World?", "Zhytomyr");
        
        repo.AddCard(testCard1);
        repo.AddCard(testCard2);
        repo.AddCard(testCard3);
        
        repo.DeleteCard(1);
        
        CardBase[] result = repo.GetCards(null);
        
        Assert.That(result.Length, Is.EqualTo(2));
        Assert.That(result[1].Question, Is.EqualTo("Capital of the World?"));
    }
    
    [Test]
    public void GetCards_WithMathCategory_ReturnsOnlyMathCards()
    {
        CardRepository repo = new CardRepository();
        
        GeographyCard testCard1 = new GeographyCard("Capital of France?", "Paris");
        MathCard testCard2 = new MathCard("3*3*3", "27");
        MathCard testCard3 = new MathCard("2 * 16?", "32");
        EnglishCard testCard4 = new EnglishCard("Hello?", "Bye?");
        
        repo.AddCard(testCard1);
        repo.AddCard(testCard2);
        repo.AddCard(testCard3);
        repo.AddCard(testCard4);
        
        CardBase[] result = repo.GetCards(CardType.Math);

        foreach (CardBase card in result)
        {
            Assert.That(card.Type, Is.EqualTo(CardType.Math));
        }
 
    }

    [Test]
    public void DeleteCard_InvalidIndex_ThrowsException()
    {
        CardRepository repo = new CardRepository();
        
        GeographyCard testCard1 = new GeographyCard("Capital of France?", "Paris");
        
        repo.AddCard(testCard1);
        
        void Delete()
        {
            repo.DeleteCard(9999);
        }
        
        Assert.Throws<IndexOutOfRangeException>(Delete);
        Assert.That(repo.GetCards(null).Length, Is.EqualTo(1));
    }

    [Test]

    public void Integration_FullScenario_WorksCorrectly()
    {
        CardRepository repo = new CardRepository();
        CardService service = new CardService(repo);
        
        //1. Geography. 2. Math. 3. English
        
        service.AddCardByParams(1, "Capital of France?", "Paris");
        service.AddCardByParams(2, "2+2?", "4");
        
        service.RemoveCard(0);
        
        service.AddCardByParams(3, "What is hello?", "It's greeting");
        service.AddCardByParams(1, "Capital of Ukraine?", "Kiev");
        
        CardBase[] report = service.GetReport(CardType.Geography);
        CardBase[] report2 = service.GetReport(null);
        
        Assert.That(report.Length, Is.EqualTo(1));
        Assert.That(report2[0].Question, Is.EqualTo("2+2?"));
        Assert.That(report2[1].Answer, Is.EqualTo("It's greeting"));
    }
    
    [Test]
    public void Integration_InvalidInput_ThrowsException()
    {
        CardRepository repo = new CardRepository();
        CardService service = new CardService(repo);

        void InterAdd()
        {
            service.AddCardByParams(99, "Capital of France?", "Paris");
        }
        
        Assert.Throws<InvalidInputException>(InterAdd);
        Assert.That(repo.GetCards(null).Length, Is.EqualTo(0));

    }
    
}