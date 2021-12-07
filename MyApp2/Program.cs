using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MyApp2;

namespace MyApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GuessingGame();
            // SimpleLoginAuth();
            // OptionMenu();
            // FizzBuzz();
            dataText();
        }

        static void dataText()
        {
            string fileName = "data.txt";
            string filePath = @"C:\Users\user\Desktop\db-demo-c-sharp";
            string fullPath = $"{filePath}\\{fileName}";
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            // Format : guid,name,weapon
            if (!File.Exists(fullPath)) File.WriteAllText(fullPath, "");

            while (true)
            {
                Console.Clear();
                DisplayMenu();
                int menuInput = SelectMenu();
                Console.WriteLine();

                switch (menuInput)
                {
                    case 1:
                        getAllNames(fullPath);
                        break;
                    case 2:
                        insertData(fullPath);
                        break;
                    case 3:

                        break;
                    case 4:
                        deleteData(fullPath);
                        break;
                }

                Console.Write("Press any key to repeat ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("======== Menu =========");
            Console.WriteLine();
            Console.WriteLine(" [1] Get All Name");
            Console.WriteLine(" [2] Insert New Data");
            Console.WriteLine(" [3] Update Data ");
            Console.WriteLine(" [4] Delete Data ");
            Console.WriteLine();
            Console.WriteLine("=======================");
        }

        static int SelectMenu()
        {
            int menuInput = 0;
            while (!(menuInput > 0 && menuInput < 5))
            {
                Console.Write("Insert your option : ");
                int.TryParse(Console.ReadLine(), out menuInput);
            }
            return menuInput;
        }

        static void dispatchSuccess(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ResetColor();
        }

        static void dispatchFail(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ResetColor();
        }

        static void deleteData(string fullPath)
        {
            string[] rows = getAllData(fullPath);
            Console.Write("Search Name to Delete : ");
            string name = Console.ReadLine().Trim();
            bool found = false;
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Length > 0)
                {
                    string[] data = rows[i].Split(',');
                    if (data[1] == name)
                    {
                        rows[i] = "";
                        found = true;
                    }
                }

            }
            if (found)
            {
                string newData = string.Join(";", rows);
                File.WriteAllText(fullPath, newData);
                dispatchSuccess("File Deleted");
            }
            else
            {
                dispatchFail("File Not Found!");
            }
        }

        static void insertData(string fullPath)
        {
            string guid = Guid.NewGuid().ToString();
            Console.Write("Enter Name : ");
            string name = Console.ReadLine().Trim();
            Console.Write("Enter Weapon : ");
            string weapon = Console.ReadLine().Trim();
            string newData = $"{guid},{name},{weapon};";
            string a = File.ReadAllText(fullPath);
            string[] rows = a.Split(';');
            // Array.Resize<string>(ref rows, rows.Length+1);
            rows[rows.Length - 1] = newData;
            string content = string.Join(";", rows);
            File.WriteAllText(fullPath, content);
            dispatchSuccess("Data Added Successfully");
        }

        static string[] getAllData(string fullPath)
        {
            string allData = File.ReadAllText(fullPath);
            string[] rows = allData.Split(';');
            return rows;
        }

        static void getAllNames(string fullPath)
        {
            string[] rows = getAllData(fullPath);
            for (int i = 0; i < rows.Length; i++)
            {

                if (rows[i].Length > 0)
                {
                    string[] data = rows[i].Split(',');
                    // Display only name
                    Console.WriteLine(data[1]);
                }
            }
            dispatchSuccess("Data Generated Successfully");
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
                if (i % multiplier == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Fizz");
                }
                else if (i % 2 != 0)
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
