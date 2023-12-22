using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Witaj w grze Lotto!");

        
        int[] lottoNumbers = GenerateLottoNumbers();

       
        int[] userNumbers = GetUserNumbers();

       
        Console.WriteLine("\nWyniki losowania:");
        DisplayNumbers("Numbers provided by the user: ", userNumbers);
        DisplayNumbers("Numbers drawn: ", lottoNumbers);

       
        int matchingNumbers = CountMatchingNumbers(userNumbers, lottoNumbers);
        Console.WriteLine($"\nNumber of hits: {matchingNumbers}");

        if (matchingNumbers == 6)
        {
            Console.WriteLine("Congratualtions! You win!!!");
        }
        else
        {
            Console.WriteLine("Unfortunately, failed. Try your luck next time!");
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
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 49 && !numbers.Contains(number))
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