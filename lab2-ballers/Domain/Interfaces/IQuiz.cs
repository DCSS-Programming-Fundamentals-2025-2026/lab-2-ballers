using lab1_ballers.Domain.Cards;

namespace lab1_ballers.Domain.Interfaces;

public interface IQuiz
{
    public void RunQuiz(CardBase[] quizCards, int points);
}