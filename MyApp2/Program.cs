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
            SimpleLoginAuth();
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
