using System;
using MyClasses;

namespace Lab6csh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stock string1:\nH1e3l5l7o9");
            MyString strNum = new NumString("H1e3l5l7o9");
            Console.WriteLine("Stock number string:\n{0}", strNum);
            strNum.MoveLetters();
            Console.WriteLine("Number string after moving fisrt element to the last pos:\n{0}", strNum);

            Console.WriteLine();

            Console.WriteLine("Stock string2:\nHeLlO mY fRiEnD");
            MyString strLow = new LowerString("HeLlO mY fRiEnD");
            Console.WriteLine("Stock lower string:\n{0}", strLow);
            strLow.MoveLetters();
            Console.WriteLine("Lower string after moving last element to the first pos:\n{0}", strLow);
            
            Console.ReadKey();
        }
    }
}
