using System;

namespace task1
{
    internal class Program
    {
        public delegate T MyDelegate<T>(T a, T b,T c);
        static void Main(string[] args)
        {
            int someResult = 0;

            //////////******** as a universal parameter - int *******\\\\\\\\\\
            MyDelegate<int> myDelegate = delegate (int a, int b, int c)
            {
                someResult = (a + b + c) / 3;
                return someResult;
            };
            Console.WriteLine("Enter 3 numbers: ");
            try
            {
                int firstArg = Convert.ToInt32(Console.ReadLine());
                int secondArg = Convert.ToInt32(Console.ReadLine());
                int thirdArg = Convert.ToInt32(Console.ReadLine());

                Console.Write(Environment.NewLine);
                someResult = myDelegate(firstArg, secondArg, thirdArg);
                Console.WriteLine($"Arithmetic mean of arguments = {someResult}");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            Console.ReadLine();
        }
    }
 
}
