using System;
using MyClass;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToText = "";
            bool stay = true;
            Console.WriteLine("Type a text:");
            while (stay)
            {
                string strTemp = Console.ReadLine();
                strToText += strTemp;
                if (strTemp == "")
                    stay = false;
                else
                    strToText += '\n';
            }
            MyText text = new MyText(strToText);

            Console.Clear();
            
            int choice = -1;
            while (true)
            {
                Console.WriteLine("Your text:");
                text.ConsoleWrite();
                Console.WriteLine();
                Console.WriteLine();

                switch (choice)
                {
                    case (1):
                        Console.Write("Type number of line to get (0 or less to go to the main menu): ");
                        int curLine = GetInt();
                        if (curLine > 0)
                        {
                            Console.Write("Choosed line:\n{0}", text[curLine - 1]);
                            Console.ReadKey();
                        }
                        else
                            choice = -1;
                        break;
                    case (2):
                        Console.Write("Number of consonant letters in text: {0}", text.NumOfConsLetters);
                        Console.ReadKey();
                        choice = -1;
                        break;
                    case (0):
                        System.Environment.Exit(0);
                        break;
                    default:
                        ShowMenu();
                        Console.Write("Choose a num from 0 to 2: ");
                        choice = GetInt();
                        break;
                }

                Console.Clear();
            }
        }
        static void ShowMenu()
        {
            string menu = "Main Menu\n" +
                          "1 - Get line of text\n" +
                          "2 - Get amount of consonant letters\n" +
                          "0 - Exit";
            Console.WriteLine(menu);
        }
        static int GetInt()
        {
            int num;

            bool success = Int32.TryParse(Console.ReadLine(), out num);
            if (!success)
            {
                num = -1;
            }

            return num;
        }
    }
}
