using System;



    class Prgram
    {
        public static int money = 50;
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("\n");
                Console.WriteLine("Account balance: " + money);
                Console.WriteLine("\n");
                Console.WriteLine("1.Lotto - cost: 20, 1 correct number = 10zł.");
                Console.WriteLine("2.End.");
                Console.Write("Choose optione: ");
                int choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {

                    Console.Clear();

                    money -= 10;

                    Console.WriteLine("Welcome in Lotto game!!!");


                    int[] lottoNumbers = GenerateNumbers();


                    int[] userNumbers = GetUserNumbers();


                    Console.WriteLine("\nDraw result:");
                    DisplayNumbers("Numbers provided by the user: ", userNumbers);
                    DisplayNumbers("Numbers drawn: ", lottoNumbers);



                    int matchingNumbers = CountMatchingNumbers(userNumbers, lottoNumbers);
                    Console.WriteLine($"\nNumber of hits: {matchingNumbers}");




                    if (matchingNumbers == 6)
                    {
                        Console.WriteLine("Congratualtions! You win!!!");
                        money += 60;
                    }
                    if (matchingNumbers == 5)
                    {
                        Console.WriteLine("Congratualtions + 50!");
                        money += 50;
                    }
                    if (matchingNumbers == 4)
                    {
                        Console.WriteLine("Congratualtions + 40!");
                        money += 40;
                    }
                    if (matchingNumbers == 3)
                    {
                        Console.WriteLine("Congratualtions + 30!");
                        money += 30;
                    }
                    if (matchingNumbers == 2)
                    {
                        Console.WriteLine("Congratualtions + 20!");
                        money += 20;
                    }
                    if (matchingNumbers == 1)
                    {
                        Console.WriteLine("Congratualtions + 10!");
                        money += 10;
                    }
                    if (matchingNumbers == 0)
                    {
                        Console.WriteLine("Unfortunately 0 to money");
                        money += 0;
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately, failed. Try your luck next time!");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    continue;

                }
                if (choose == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Game is over");
                    Console.WriteLine("Account balance: " + money);
                    break;
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