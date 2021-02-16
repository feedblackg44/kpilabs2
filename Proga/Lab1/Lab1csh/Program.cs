using System;

namespace Prog1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program by: Plostak Illia IS-02\n");
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
            bool highestBit = true;                     // decide if it's a highest bit or not
            int iter = 1 << (sizeof(int) * 8 - 2);      // iterator to cross over all bits

            while (Convert.ToBoolean(iter))
            {
                if (Convert.ToBoolean(num1 & iter ^ num2 & iter))
                {
                    if (highestBit)
                        return Convert.ToBoolean(num2 & iter);
                    else
                        return Convert.ToBoolean(num1 & iter);
                }
                else
                    highestBit = false;
                iter >>= 1;
            }

            return false;
        }
        static void dekrement(ref int num)
        {
            int iter = 1;           // iterator to cross over all bits
            while (Convert.ToBoolean(iter))
            {
                num ^= iter;
                if (Convert.ToBoolean(num & iter))
                    iter <<= 1;
                else
                    iter = 0;
            }
        }
    }
}
