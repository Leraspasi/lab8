using System;

namespace task2
{
    internal class Program
    {
        public delegate int MyDelegate1();
        public delegate int MyDelegate2(MyDelegate1[] myDelegates);
        static void Main(string[] args)
        {

            MyClass myClass1 = new MyClass();
            MyDelegate1[] delegate1 = new MyDelegate1[]
            {
                myClass1.Method1,myClass1.Method2,myClass1.Method3
            };
            int[] arr = new int[delegate1.Length];
            MyDelegate2 myDelegate2 = delegate (MyDelegate1[] massive)
            {
                Console.WriteLine("Array OutPut: ");
                Console.Write(Environment.NewLine);

                for (int i = 0; i < delegate1.Length; i++)
                {
                    arr[i] = delegate1[i]();
                    Console.WriteLine(arr[i]);
                }
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum = sum + arr[i];
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Sum = { sum}");
                return sum / (massive.Length);
            };

            Console.Write("\n");
            Console.WriteLine($"Arithmetic mean of array numbers = {myDelegate2(delegate1)}");

            Console.ReadKey();
        }

    }
    public class MyClass
    {
        public static Random rand = new Random();
        public static int Randomizer() => rand.Next(1, 10);
        public int Method1() { return Randomizer(); }
        public int Method2() { return Randomizer(); }
        public int Method3() { return Randomizer(); }

    }
}

