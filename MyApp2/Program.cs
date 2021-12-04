using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GuessingGame();
            // SimpleLoginAuth();
            // OptionMenu();
            FizzBuzz();
        }

        static void FizzBuzz()
        {
            Console.WriteLine("===== Welcome to FizzBuzz! =====");
            Console.WriteLine();
            Console.WriteLine("How many times should I loop?");
            Console.Write("Enter a number: ");
            int number;
            int.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("Which multiplier should I generate both Fizz and Buzz?");
            Console.Write("Enter a number: ");
            int multiplier;
            int.TryParse(Console.ReadLine(), out multiplier);
            Console.WriteLine();
            Console.WriteLine($"Generating {number} loops");
            Console.WriteLine($"Even number is Fizz, odd number is Buzz, and the multiplier of {multiplier} is FizzBuzz!");
            Console.WriteLine();
            for (int i = 1; i <= number; i++)
            {
                if(i % multiplier == 0)
                {   
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("FizzBuzz");
                } else if(i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Fizz");
                } else if (i % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Buzz");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        static void OptionMenu()
        {
            int items = 3;
            int current = 0;
            bool done = false;

            while (!done)
            {
                for (int i = 1; i <= items; i++)
                {
                    if (current == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine("item " + i);

                    Console.ResetColor();
                }

                // Arrow conditional handling
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        current = Math.Max(1, current - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        current = Math.Min(items, current + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }

                // Render only once, always on top
                if (!done)
                    Console.CursorTop = Console.CursorTop - items;
            }

            Console.WriteLine();
            Console.WriteLine($"You have select {current}.");
        }

        static void SimpleLoginAuth()
        {
            string username = "admin";
            string password = "123";
            int count = 3;

            while (count > 0)
            {
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine();
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                if (usernameInput == username && passwordInput == password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login success!");
                    Console.ResetColor();
                    break;

                }
                else
                {
                    count--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Login failed, chance to attemp : {count}");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            if (count == 0) Console.WriteLine("Login failed 3 times, rejected by program");
        }

        static void GuessingGame()
        {
            /* Guessing a game between random number */

            Random rnd = new Random();
            int firstNum = 1;
            int secondNum = 10;
            int target = rnd.Next(firstNum, secondNum);
            Console.WriteLine($"Guess the number between {firstNum} and {secondNum}!");
            int life = 3;
            do
            {
                Console.Write("Enter Your Guess: ");
                var answer = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                if (answer == target)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You did it! the correct number is {target}");
                    Console.WriteLine("You Win!");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    life--;
                    if (life > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong, the number is " + ((answer < target) ? "greater" : "less") + " than your answer"); 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The correct number is {target}");
                    }
                    Console.ResetColor();
                    Console.WriteLine("You " + ((life == 0) ? "are running out of chance!" : $"have {life} chance left"));
                };
            }
            while (life > 0);

            if (life == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lose!");
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void Sum()
        {
            Console.WriteLine("Enter first number");
            var a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            var b = Int32.Parse(Console.ReadLine());
            Console.Write("Result: ");
            Console.WriteLine(a + b);
        }

        static void StarTreeGenerator()
        {
            Console.WriteLine("Enter a number");
            var a = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"The following star triangle tree will be repeated {a} times");
            Console.WriteLine();

            for (int i = a; i >= 1; i--)
            {
                for (int x = 1; x <= i; x++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }


    }
}
