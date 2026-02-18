using lab1_ballers.Domain.CardsRepos;
using lab1_ballers.Domain.Exceptions;

namespace lab1_ballers.App;

public class DemoRunner
{
    private CardService _service;

    public DemoRunner()
    {
        CardRepository repo = new CardRepository();
        _service = new CardService(repo);
    }

    public void Run()
    {
        Menu menu = new Menu(_service);
        menu.StartMenu();
    }
}