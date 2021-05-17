using System;
using MyClasses;

namespace Lab8csh
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list1 = new MyList();
            Random random = new Random();

            for (long i = 0; i < 20; i++)
            {
                long current = random.Next(1, 20);
                list1.put(current);
            }

            Console.WriteLine("Genereated list: {0}", list1);

            Console.WriteLine("\nAmount of elements that stands on even positions and can be divided by 5: {0}", list1.CountElemDivBy5OnEvenPos());

            long avg = list1.CountAverageLower();
            list1.RemoveElementsMoreThanAverage();

            Console.WriteLine("\nAverage rounded to lower of this list is: {0}\nThe modified list is: {1}", avg, list1);
            Console.ReadKey();
        }
    }
}
