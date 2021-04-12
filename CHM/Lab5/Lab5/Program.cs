using System;
using MyClass;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrX = { -5, -3, -1, 1, 3 };
            Func<double, double> FuncToPolynom = x => Math.Sin(x) + Pow(2 * x, 1.0 / 3.0);
            LagrangePolynom poly1 = new LagrangePolynom(arrX, FuncToPolynom);

            poly1.CalculateLagrange();

            Console.WriteLine("Result polynom is:");
            Console.WriteLine(poly1);
            Console.WriteLine();

            QuadraticPolynom poly2 = new QuadraticPolynom(arrX, FuncToPolynom);
            Console.WriteLine("Result polynoms are:");
            for (int i = 0; i < poly2.Length; i++)
                Console.WriteLine("\t{0}", poly2[i]);
            
            Console.WriteLine();
            for (double i = arrX[0]; i <= arrX[arrX.Length - 1]; i += (arrX[1] - arrX[0]) / 5)
                Console.WriteLine("Error of Lagrange polynom in {0}: {1}", Math.Round(i, 1), Math.Abs(Math.Round((RoflanLagrangeCalculate(Math.Round(i, 1)) - FuncToPolynom(Math.Round(i, 1))), 6)));
            Console.WriteLine();
            for (double i = arrX[0]; i <= arrX[arrX.Length - 1]; i += (arrX[1] - arrX[0]) / 5)
            {
                if (i < arrX[1])
                    Console.WriteLine("Error of Spline polynom in {0}: {1}", Math.Round(i, 1), Math.Abs(Math.Round((RoflanSplineCalculate(Math.Round(i, 1), 1) - FuncToPolynom(Math.Round(i, 1))), 6)));
                else if (i < arrX[2])
                    Console.WriteLine("Error of Spline polynom in {0}: {1}", Math.Round(i, 1), Math.Abs(Math.Round((RoflanSplineCalculate(Math.Round(i, 1), 2) - FuncToPolynom(Math.Round(i, 1))), 6)));
                else if (i < arrX[3])
                    Console.WriteLine("Error of Spline polynom in {0}: {1}", Math.Round(i, 1), Math.Abs(Math.Round((RoflanSplineCalculate(Math.Round(i, 1), 3) - FuncToPolynom(Math.Round(i, 1))), 6)));
                else
                    Console.WriteLine("Error of Spline polynom in {0}: {1}", Math.Round(i, 1), Math.Abs(Math.Round((RoflanSplineCalculate(Math.Round(i, 1), 4) - FuncToPolynom(Math.Round(i, 1))), 6)));
            }

            Console.ReadKey();
        }
        public static double Pow(double x, double power)
        {
            bool IsThereMinus = false;
            if (x < 0)
                IsThereMinus = true;

            double numOut = Math.Pow(Math.Abs(x), power);

            if (IsThereMinus)
                return -numOut;
            else
                return numOut;
        }
        public static double RoflanLagrangeCalculate(double x)
        {
            return -1.19551 * ((x + 3) / 2 * (x + 1) / 4 * (x - 1) / 6 * (x - 3) / 8) +
                   1.958241 * ((x + 5) / 2 * (x + 1) / 2 * (x - 1) / 4 * (x - 3) / 6) - 
                   2.101392 * ((x + 5) / 4 * (x + 3) / 2 * (x - 1) / 2 * (x - 3) / 4) -
                   2.101392 * ((x + 5) / 6 * (x + 3) / 4 * (x + 1) / 2 * (x - 3) / 2) +
                   1.958241 * ((x + 5) / 8 * (x + 3) / 6 * (x + 1) / 4 * (x - 1) / 2);
        }
        public static double RoflanSplineCalculate(double x, int index)
        {
            switch (index)
            {
                case 1:
                    return -1.19551 - 0.319111 * (x + 5) + 0 * (x + 5) * (x + 5) - 0.015564 * (x + 5) * (x + 5) * (x + 5);
                case 2:
                    return -1.958241 - 0.505873 * (x + 3) - 0.093381 * (x + 3) * (x + 3) + 0.155265 * (x + 3) * (x + 3) * (x + 3);
                case 3:
                    return -2.101392 + 0.983781 * (x + 1) + 0.838208 * (x + 1) * (x + 1) - 0.139701 * (x + 1) * (x + 1) * (x + 1);
                case 4:
                    return 2.101392 - 0.071576 * (x - 1) + 0 * (x - 1) * (x - 1) + 0 * (x - 1) * (x - 1) * (x - 1);
            }
            return -1;
        }
    }
}
