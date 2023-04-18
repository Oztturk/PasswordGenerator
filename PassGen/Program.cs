using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace PassGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tag();
            string uppercasess = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerCases = "abcdefghijklmnopqrstuvwxyz";
            string specialChars = "!@#$%^&*()_+";
            string numbers = "0123456789";

            (int number ,bool spec, bool upperCases, bool Numbers,bool save) = prompt();
            while (true)
            {
                StringBuilder password = new StringBuilder();
                Random random = new Random();
                for (int i = 0; i < number; i++)
                {
                    if (spec && i % 5 == 0)
                    {
                        int index = random.Next(specialChars.Length);
                        password.Append(specialChars[index]);
                    }
                    else if (Numbers && i % 3 == 0)
                    {
                        int index = random.Next(numbers.Length);
                        password.Append(numbers[index]);
                    }
                    else if (upperCases && i % 2 == 0)
                    {
                        int index = random.Next(uppercasess.Length);
                        password.Append(uppercasess[index]);
                    }
                    else
                    {
                        int index = random.Next(lowerCases.Length);
                        password.Append(lowerCases[index]);
                    }
                }
                Console.Write("Generated password: ");
                ConsoleColor color = number < 8 ? ConsoleColor.Red : (number >= 8 && number <= 16 ? ConsoleColor.Yellow : ConsoleColor.Green);
                Console.ForegroundColor = color;
                Console.WriteLine($"{password}\n");
                if (save) { savePassword(password.ToString()); }
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        static (int,bool,bool,bool,bool) prompt()
        {
            Main:
            Console.Write("length of password > ");
            string parseTo = Console.ReadLine();
            int number;
            if (!int.TryParse(parseTo, out number))
            {
                Console.WriteLine("Please enter a valid number.");
                Thread.Sleep(1800);
                Console.Clear();
                goto Main;
            }

            Console.Clear();

            Console.Write("Length: ");
            ConsoleColor color = number < 8 ? ConsoleColor.Red : (number >= 8 && number <= 16 ? ConsoleColor.Yellow : ConsoleColor.Green);
            Console.ForegroundColor = color;
            Console.Write($"{number}\n");
            Console.ResetColor();

            Console.WriteLine("Add Special Chars (Y/N)");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            bool useSpecialChars = (keyInfo.KeyChar == 'Y' || keyInfo.KeyChar == 'y');

            Console.Clear();

            Console.Write("Length: ");
            Console.ForegroundColor = color;
            Console.Write($"{number}\n");
            Console.ResetColor();

            Console.Write($"Special Chars: ");
            Console.ForegroundColor = useSpecialChars ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{useSpecialChars}\n");
            Console.ResetColor();

            Console.WriteLine("Add Upper Cases (Y/N)");
            ConsoleKeyInfo upperCaseInfo = Console.ReadKey();
            bool upperCases = (upperCaseInfo.KeyChar == 'Y' || upperCaseInfo.KeyChar == 'y');
            Console.Clear();

            Console.Write("Length: ");
            Console.ForegroundColor = color;
            Console.Write($"{number}\n");
            Console.ResetColor();

            Console.Write($"Special Chars: ");
            Console.ForegroundColor = useSpecialChars ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{useSpecialChars}\n");
            Console.ResetColor();

            Console.Write($"Upper Cases: ");
            Console.ForegroundColor = upperCases ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{upperCases}\n");
            Console.ResetColor();

            

            Console.WriteLine("Add Numbers (Y/N)");
            ConsoleKeyInfo NumbersInfo = Console.ReadKey();
            bool Numbers = (NumbersInfo.KeyChar == 'Y' || NumbersInfo.KeyChar == 'y');
            Console.Clear();

            Console.Write("Length: ");
            Console.ForegroundColor = color;
            Console.Write($"{number}\n");
            Console.ResetColor();

            Console.Write($"Special Chars: ");
            Console.ForegroundColor = useSpecialChars ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{useSpecialChars}\n");
            Console.ResetColor();

            Console.Write($"Upper Cases: ");
            Console.ForegroundColor = upperCases ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{upperCases}\n");
            Console.ResetColor();

            Console.Write($"Numbers: ");
            Console.ForegroundColor = Numbers ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{Numbers}\n");
            Console.ResetColor();

            Console.WriteLine("Save Generated Passwords (Y/N)");
            ConsoleKeyInfo SaveInfo = Console.ReadKey();
            bool saveVal = (SaveInfo.KeyChar == 'Y' || SaveInfo.KeyChar == 'y');
            Console.Clear();

            Console.Write("Length: ");
            Console.ForegroundColor = color;
            Console.Write($"{number}\n");
            Console.ResetColor();

            Console.Write($"Special Chars: ");
            Console.ForegroundColor = useSpecialChars ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{useSpecialChars}\n");
            Console.ResetColor();

            Console.Write($"Upper Cases: ");
            Console.ForegroundColor = upperCases ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{upperCases}\n");
            Console.ResetColor();

            Console.Write($"Numbers: ");
            Console.ForegroundColor = Numbers ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{Numbers}\n");
            Console.ResetColor();

            Console.Write($"Save Generated Passwords : ");
            Console.ForegroundColor = saveVal ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{saveVal}\n");
            Console.ResetColor();

            return (number,useSpecialChars, upperCases, Numbers, saveVal);
        }
        static void tag()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
             ________  ________  _________  _________  ___  ___  ________  ___  __       
            |\   __  \|\_____  \|\___   ___\\___   ___\\  \|\  \|\   __  \|\  \|\  \     
            \ \  \|\  \\|___/  /\|___ \  \_\|___ \  \_\ \  \\\  \ \  \|\  \ \  \/  /|_   
             \ \  \\\  \   /  / /    \ \  \     \ \  \ \ \  \\\  \ \   _  _\ \   ___  \  
              \ \  \\\  \ /  /_/__    \ \  \     \ \  \ \ \  \\\  \ \  \\  \\ \  \\ \  \ 
               \ \_______\\________\   \ \__\     \ \__\ \ \_______\ \__\\ _\\ \__\\ \__\
                \|_______|\|_______|    \|__|      \|__|  \|_______|\|__|\|__|\|__| \|__|
            ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\t\t\t\tversion: 1.0 | {DateTime.Now}\n\n\n");
            Console.ResetColor();
        }

        static void savePassword(string pw)
        {
            string fileName = "generated password.txt";

            string exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(exePath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                writer.WriteLine(formattedDate + " | " + pw);
            }

        }
    }
}
