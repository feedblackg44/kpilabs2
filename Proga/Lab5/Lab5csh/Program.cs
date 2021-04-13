using System;
using MyClasses;

namespace Lab5csh
{
    class Program
    {
        static void Main(string[] args)
        {
            Segment seg = new Segment(1, 1, 7, 9);

            Console.WriteLine("Current Length: {0}", seg.Length);
            double[][] curCoords = seg.Coords;
            Console.WriteLine("Current Coords:");
            for (int i = 0; i < 2; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", curCoords[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            seg.RestrictByFive();
            Console.WriteLine("Segment restricted by 5");
            Console.WriteLine();

            Console.WriteLine("Current Length: {0}", seg.Length);
            curCoords = seg.Coords;
            Console.WriteLine("Current Coords:");
            for (int i = 0; i < 2; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", curCoords[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
