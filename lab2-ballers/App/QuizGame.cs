using lab1_ballers.Domain;
using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.Interfaces;

namespace lab1_ballers.App;

public class QuizGame : IQuiz
{
    public int[] wrongIndexes = new int[200];
    public void RunQuiz(CardBase[] playCards, int points)
    {
        if (playCards.Length == 0)
        {
            Console.WriteLine(" No cards found for quiz");
            return;
        }
        Console.Clear();
        Console.WriteLine(" GAME STARTED");
        
        int totalPoints = 0;
        int wrongIndexesCount = 0;

        for (int i = 0; i < playCards.Length; i++)
        {
            Console.WriteLine($" Question #{i+1}: {playCards[i].Question}");
            Console.Write(" Your answer: ");
            string answer = Console.ReadLine();

            if (answer == playCards[i].Answer)
            {
                totalPoints++;
                wrongIndexes[i] = 1;
            }
            
            else wrongIndexesCount++;
        }
        
        totalPoints *= points;
        
        int[] wrongIndexesArray = new int[wrongIndexesCount];

        int count = 0;
        
        for (int i = 0; i < playCards.Length; i++)
        {
            if (wrongIndexes[i] == 0)
            {
                wrongIndexesArray[count] = i+1;
                count++;
            }
        }

        Console.WriteLine($" END OF THE QUIZ!" +
                          $"\n Total points: {totalPoints}");
        
        Console.WriteLine($" Correct answers: {playCards.Length - wrongIndexesArray.Length}/{playCards.Length}!");
        
        Console.WriteLine(" Incorrect answered questions:");

        if (wrongIndexesArray.Length > 0)
        {
            foreach (int i in wrongIndexesArray)
                Console.Write($"№{i} ");

            Console.Write(".");
        }

        else
        {
            Console.Write("0!");
        }

        Console.WriteLine("\n Press enter to continue...");
        Console.ReadLine();
    }
}