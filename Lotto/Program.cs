using System;

namespace Lotto;

class Program
{
    static void Main()
    {
        int money = 50;
        while (true)
        {
            Console.Write($"""
                           Welcome!

                           Account balance: {money}

                           1.Play lotto cost: 10
                           2.End
                           

                           """);

            string option = Console.ReadLine();

            if (option == "2")
            {
                Console.Clear();
                Console.WriteLine($"End. Your money result: {money}");
                break;
            }

            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Welcome to Lotto game!!!");

                money -= 10;

                int[] lottoNumbers = GenerateNumbers();
                int[] userNumbers = GetUserNumbers();


                Console.WriteLine("\nDraw result: ");
                DisplayNumbers("Numbers provided by the user: ", userNumbers);
                DisplayNumbers("Numbers drawn: ", lottoNumbers);


                int matchingNumbers = CountMatchingNumbers(userNumbers, lottoNumbers);
                Console.WriteLine($"\nNumber of hits: {matchingNumbers}");


                money += matchingNumbers * 10;
                if (matchingNumbers == 6)
                {
                    Console.WriteLine("Congratualtions! You win!!!");
                }
                else if (matchingNumbers > 0)
                {
                    Console.WriteLine($"Congratualtions, You won {matchingNumbers * 10}$");
                }
                else
                {
                    Console.WriteLine("Unfortunately, failed. Try your luck next time!");
                }

                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
                continue;
                
            }

            
        }
    }

    static int[] GenerateNumbers()
    {
        Random random = new Random();
        return Enumerable.Range(1, 49).OrderBy(_ => random.Next()).Take(6).ToArray();
    }

    static int[] GetUserNumbers()
    {
        int[] numbers = new int[6];
        Console.WriteLine("\nEnter 6 unique numbers from 1 to 49");

        for (int i = 0; i < 6; i++)
        {
            while (true)
            {
                Console.Write($"Number {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 49 &&
                    !numbers.Contains(number))
                {
                    numbers[i] = number;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number, please try again");
                }
            }
        }

        return numbers;
    }

    static void DisplayNumbers(string message, int[] numbers)
    {
        Console.WriteLine($"{message} {string.Join(", ", numbers)}");
    }

    static int CountMatchingNumbers(int[] userNumbers, int[] lottoNumbers)
    {
        return userNumbers.Count(num => lottoNumbers.Contains(num));
    }
}