using System;
using MyClass;

namespace Lab9csh
{
    class Program
    {
        delegate string MyTestDelegate1(string[] arr);
        delegate string MyTestDelegate2();
        static void Main(string[] args)
        {
            // First task
            string[] strArray = { "Hello there",
                                  "Wonderful",
                                  "Did it!",
                                  "I am clever",
                                  "End of test" };
            Test test = new Test(strArray);
            MyTestDelegate1 delegate1 = new MyTestDelegate1(Test.StaticMainDiag);
            MyTestDelegate2 delegate2 = new MyTestDelegate2(test.ExMainDiag);
            print(delegate1, strArray);
            print(delegate2);

            // End of the first task
            Console.WriteLine("----------------------------------------");
            // Second task
            MobileAccount account = new MobileAccount("Test");
            account.Activate();
            Console.WriteLine("Your account has been activated!");
            account.AddMoney(100);
            Console.WriteLine("Now you have {0} gryvnas.", account.AddMoney(100));
            account.MyEvent += EndOfMoney;
            Console.WriteLine("You talked during 4 days.");
            account.Talk(4);
            Console.WriteLine("You talked during 6 days.");
            account.Talk(6);
            Console.ReadKey();
            // End of the second task
        }
        static void EndOfMoney()
        {
            Console.WriteLine("You have no money!");
        }
        static void print(MyTestDelegate1 delegate1, string[] arr)
        {
            Console.WriteLine(delegate1(arr));
        }
        static void print(MyTestDelegate2 delegate2)
        {
            Console.WriteLine(delegate2());
        }
    }
}
