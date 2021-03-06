using System;
using MyClasses;

namespace Lab2csh
{
    class Program
    {
        static void Main(string[] args)
        {
            MyText   curText = new MyText(),
                     menu = new MyText();
            int      choise = -1;

            menuInit(menu);

            while (true)
            {
                Console.WriteLine("Current text:");
                curText.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                switch (choise)
                {
                    case (1):
                        Console.Write("\nType a position of new string (0 to go to main menu): ");
                        int strNum = GetInt();
                        MyString curString = new MyString();
                        if (Convert.ToBoolean(strNum))
                        {
                            Console.Write("\nType a string: ");
                            curString.getline();
                            curText.AddString(curString, strNum);
                        }
                        else
                            choise = -1;
                        break;
                    case (2):
                        Console.Write("\nType a position to delete a string (0 to go to main menu): ");
                        strNum = GetInt();
                        if (Convert.ToBoolean(strNum))
                        {
                            curText.RemoveString(strNum);
                        }
                        else
                            choise = -1;
                        break;
                    case (3):
                        curText.Clear();
                        choise = -1;
                        break;
                    case (4):
                        curText = curText.TextUpperCase();
                        choise = -1;
                        break;
                    case (5):
                        Console.Write("\nType a number of string (0 to go to main menu): ");
                        strNum = GetInt();
                        if (Convert.ToBoolean(strNum))
                        {
                            Console.Write("\nKeyWord: ");
                            curText[strNum - 1].KeyWord().WriteLine();
                            Console.ReadKey();
                        }
                        else
                            choise = -1;
                        break;
                    case (6):
                        Console.Write("\nType a length (0 to go to main menu): ");
                        strNum = GetInt();
                        if (Convert.ToBoolean(strNum))
                        {
                            Console.Write("\nNumber of strings of a given length: {0}", curText.GetNumberOfStrings(strNum));
                            Console.ReadKey();
                        }
                        else
                            choise = -1;
                        break;
                    case (0):
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        menu.WriteLine();
                        Console.WriteLine();
                        Console.Write("Choose a num from 0 to 6: ");
                        choise = GetInt();
                        break;
                }
                Console.Clear();
            }
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

        static void menuInit(MyText menu)
        {
            MyString menuHead = new MyString("Main menu:"),
                     menu1 = new MyString("1 - Add a string to the text"),
                     menu2 = new MyString("2 - Remove a string from the text"),
                     menu3 = new MyString("3 - Clear text"),
                     menu4 = new MyString("4 - Make the first letters of all words in the text uppercase "),
                     menu5 = new MyString("5 - Get the \"key string\" of a string of text"),
                     menu6 = new MyString("6 - Get the number of strings of a given length"),
                     menu0 = new MyString("0 - Exit");

            menu.AddString(menuHead, -1);
            menu.AddString(menu1, -1);
            menu.AddString(menu2, -1);
            menu.AddString(menu3, -1);
            menu.AddString(menu4, -1);
            menu.AddString(menu5, -1);
            menu.AddString(menu6, -1);
            menu.AddString(menu0, -1);
        }
    }
}
