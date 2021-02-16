using System;

namespace Prog1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print 2 numbers to compare. First number will be decremented by 1:");

            int a = Convert.ToInt32(Console.ReadLine());            // 1 number to compare
            int b = Convert.ToInt32(Console.ReadLine());            // 2 number to compare

            string output;                                          // output string which depends on compare of numbers

            if (moreThan(a, b))
                output = "Yes, a > b!";
            else
                output = "No, a <= b!";

            dekrement(ref a);

            Console.WriteLine(output);
            Console.WriteLine("а-- = " + Convert.ToString(a));
            Console.ReadLine();
        }
        static bool moreThan(int num1, int num2)
        {
            bool output = false;            // output bool variable which depends on compare of numbers
            bool highestBit = true;         // decide if it's a highest bit or not
            for (int i = sizeof(int) * 8 - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(num1 >> i ^ num2 >> i))
                {
                    if (highestBit)
                        output = Convert.ToBoolean(num2 & (1 << i));
                    else
                        output = Convert.ToBoolean(num1 & (1 << i));
                    break;
                }
                else
                    highestBit = false;
            }

            return output;
        }
        static void dekrement(ref int num)
        {
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                num = num ^ (1 << i);
                if (Convert.ToBoolean(num & (1 << i)))
                    continue;
                break;
            }
        }
    }
}
