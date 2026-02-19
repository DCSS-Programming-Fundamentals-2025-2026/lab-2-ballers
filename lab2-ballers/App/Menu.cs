using System.Linq.Expressions;
using lab1_ballers.Domain.Cards;
using lab1_ballers.Domain.CardsRepos;
using lab1_ballers.Domain.Enums;
using lab1_ballers.Domain.Exceptions;
using lab1_ballers.Domain.Interfaces;
using lab1_ballers.Upgrade;

namespace lab1_ballers.App;

public class Menu
{
    public static void StartMenu()
    {
        CardRepository repo = new CardRepository();
        Console.Clear();
        while (true)
        {
            try
            {
                Console.Write("############################################" +
                              "\n1)  QuizTime :D" +
                              "\n2)  Create a Quiz Card" +
                              "\n3)  Redact a Quiz Card" +
                              "\n4)  Delete a Quiz Card" +
                              "\n5)  Print Quiz Cards" +
                              "\n6)  Test Enumerator" +
                              "\n7)  Natural Sort" +
                              "\n8)  Alternative Sort" +
                              "\n0)  Exit" +
                              "\n############################################" +
                              "\n Select: ");

                string select = Console.ReadLine();
                Console.Clear();

                //QuizTime
                if (select == "1")
                {
                    QuizTime(repo);
                }

                //Create a card
                else if (select == "2")
                {
                    Console.Write("############################################" +
                                  "\n Card Types:" +
                                  "\n1)  Geography" +
                                  "\n2)  Math" +
                                  "\n3)  English" +
                                  "\n0)  Back" +
                                  "\n############################################" +
                                  "\n Enter the Type of a Card: ");

                    int t = int.Parse(Console.ReadLine());

                    Console.Write(" Enter the question: ");
                    string q = Console.ReadLine();

                    Console.Write(" Enter the answer: ");
                    string a = Console.ReadLine();

                    CardBase card = null;

                    if (t == 1)
                        card = new GeographyCard(q, a);

                    else if (t == 2)
                        card = new MathCard(q, a);


                    else if (t == 3)
                        card = new EnglishCard(q, a);

                    else if (t == 0)
                    {
                        continue;
                    }

                    else
                    {
                        throw new InvalidInputException();
                    }

                    repo.AddCard(card);

                }

                //Redact a card
                else if (select == "3")
                {
                    CardBase[] cards = repo.GetCards(null);
                    PrintDeck(cards);
                    Console.WriteLine(" What card do you want to redact?");
                    int i = int.Parse(Console.ReadLine());

                    CardBase card = repo.GetCard(i);

                    if (card == null)
                    {
                        throw new NoCardsFoundException("⚠ No card found");
                    }

                    Console.Write("############################################" +
                                  "\nWhat property of this card do you want to redact?" +
                                  "\n1)  Question" +
                                  "\n2)  Answer" +
                                  "\n############################################" +
                                  "\n Select: ");

                    int prop = int.Parse(Console.ReadLine());

                    if (prop == 1)
                    {
                        Console.Write("############################################" +
                                      $"\n\n Old question: {card.Question}" +
                                      "\n\n############################################" +
                                      "\n New question: ");

                        string quest = Console.ReadLine();

                        card.Question = quest;
                        Console.WriteLine(" Proceed");
                    }

                    else if (prop == 2)
                    {
                        Console.Write($" Old answer: {card.Answer}" +
                                      "\n New answer: ");

                        string answ = Console.ReadLine();

                        card.Answer = answ;
                        Console.WriteLine(" Proceed");
                    }

                    else
                    {
                        throw new InvalidInputException();
                    }
                }

                //Delete a card
                else if (select == "4")
                {
                    Console.Clear();
                    CardBase[] workCards = repo.GetCards(null);

                    PrintDeck(workCards);

                    Console.WriteLine("  What card do you want to delete?");
                    int i = int.Parse(Console.ReadLine());

                    repo.DeleteCard(i);
                    Console.WriteLine($" Proceed");
                }

                //Print cards
                else if (select == "5")
                {
                    Console.Write("############################################" +
                                  "\nWhat type of card?" +
                                  "\n1.  Geography" +
                                  "\n2.  Math" +
                                  "\n3.  English" +
                                  "\n4.  All cards" +
                                  "\n0)  Back" +
                                  "\n############################################" +
                                  "\n Enter: ");
                    int type = int.Parse(Console.ReadLine());

                    CardBase[] printCards = null;

                    if (type == 1)
                        printCards = repo.GetCards(CardType.Geography);

                    else if (type == 2)
                        printCards = repo.GetCards(CardType.Math);

                    else if (type == 3)
                        printCards = repo.GetCards(CardType.English);

                    else if (type == 4)
                        printCards = repo.GetCards(null);
                    else if (type == 0)
                    {
                        continue;
                    }
                    else
                        throw new InvalidInputException();

                    PrintDeck(printCards);

                    Console.Write(" Press enter to continue: ");
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (select == "6")
                {
                    if (repo.counter != 0)
                    {
                        var it = repo.GetEnumerator();
                        Console.WriteLine($"Here are all cards: ");
                        while (it.MoveNext() && it.Current != null)
                        {
                            Console.WriteLine(it.Current.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Create some cards first.");
                    }
                }
                else if (select == "7")
                {
                    repo.NaturalSort();
                    Console.WriteLine("Sorted cards.");
                    foreach (var card in repo.cards)
                    {
                        if (card != null)
                        {
                            Console.WriteLine($"{card.ToString()}");
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                else if (select == "8")
                {
                    repo.AlternativeSort();
                    Console.WriteLine("Sorted cards:");
                    foreach (var card in repo.cards)
                    {
                        if (card != null)
                        {
                            Console.WriteLine($"{card.ToString()}");
                        }
                    }
                }

                //Exit
                else if (select == "0")
                {
                    break;
                }

                else
                {
                    throw new InvalidInputException();
                }

            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (NoCardsFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine($"⚠ Unexpected error: {e.Message}");
            }
        }
    }
    private static void PrintDeck(CardBase[] deck)
    {
        if (deck == null || deck.Length == 0)
        {
            throw new NoCardsFoundException();
        }

        for (int i = 0; i < deck.Length; i++)
        {
            Console.WriteLine($"{i}) {deck[i]}");
        }
    }


    private static void QuizTime(CardRepository repo)
    {
        Console.Write("############################################" +
                      "\n|| It's time for a Quiz :D ||" +
                      "\n1)  Geography " +
                      "\n2)  Math" +
                      "\n3)  English" +
                      "\n4)  Mix them all" +
                      "\n0)  Back" +
                      "\n############################################" +
                      "\n Select: ");

        int select = int.Parse(Console.ReadLine());

        CardBase[] playCards = repo.GetCards(null);

        if (select >= 1 && select <= 3)
        {
            if (select == 1)
                playCards = repo.GetCards(CardType.Geography);

            else if (select == 2)
                playCards = repo.GetCards(CardType.Math);

            else if (select == 3)
                playCards = repo.GetCards(CardType.English);

            Console.WriteLine($" So it's time for a {(CardType)select} Quiz!!!");
        }

        else if (select == 4)
            Console.WriteLine(" It's time for a mixed Quiz!!!");

        else if (select == 0)
            return;

        else
        {
            throw new InvalidInputException();
        }

        Console.Write(" Choose number of points for every correct answer:");
        int points = int.Parse(Console.ReadLine());

        IQuiz game = new QuizGame();
        game.RunQuiz(playCards, points);
    }


}
