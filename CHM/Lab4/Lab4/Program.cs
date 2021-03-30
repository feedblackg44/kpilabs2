using System;
using MyClass;

namespace Lab4csh
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 4;
            SquareMatrix matrix = new SquareMatrix(size);
            matrix.matrix4x4Init();
            Console.WriteLine("Matrix A (stock matrix):");
            matrix.WriteToConsole();
            Console.WriteLine();
            Console.WriteLine();
            matrix = matrix.toFrobenius();
            Console.WriteLine("Matrix P (Frobenius normal form):");
            matrix.WriteToConsole();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
