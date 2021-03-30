using System;
using MyClass;

namespace Lab4csh
{
    class Program
    {
        static void Main(string[] args)
        {
            Romb R2 = new Romb();
            double[,] crdsR2 = { { 0.0, 4.0}, { -2.0, 0.0}, { 0.0, -4.0}, { 2.0, 0.0} };
            double[][] coordsR2 = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                coordsR2[i] = new double[2];
                for (int j = 0; j < 2; j++)
                {
                    coordsR2[i][j] = crdsR2[i,j];
                }
            }
            Romb R3 = new Romb(coordsR2);
            Console.WriteLine("Coords of R2:");
            R2.WriteToConsole();
            Console.WriteLine();
            Console.WriteLine("Coords of R3:");
            R3.WriteToConsole();
            Console.WriteLine();
            Console.WriteLine();

            R3 = R3 * 2;

            Romb R1 = new Romb(R3 - R2);

            Console.WriteLine("Coords of R1:");
            R1.WriteToConsole();
            Console.WriteLine();
            Console.WriteLine("Perimeter of R1: {0}", Math.Round(R1.Perimeter, 2));
            Console.WriteLine("Square of R1: {0}", Math.Round(R1.Square, 2));
            double[] Angles = R1.GetAngles();
            Console.WriteLine("Angles of R1: {0, -7} {1, -7}", Math.Round(Angles[0], 2), Math.Round(Angles[1], 2));
            Console.WriteLine("Side of R1: {0}", Math.Round(R1.Side, 2));
            Console.ReadKey();
        }
    }
}
