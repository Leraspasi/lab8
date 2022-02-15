using System;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter math example ");
                ////////****** Checking for invalid data entry ******\\\\\\\
                try
                {
                    string expression = Console.ReadLine();

                    int pos = expression.IndexOfAny(new char[] { '*', '/', '+', '-' });
                    var a = Convert.ToDouble(expression.Substring(0, pos));
                    var b = Convert.ToDouble(expression.Substring(pos + 1, expression.IndexOf('=') - 1 - pos));

                    MethBox(expression, a, b);
                }
                catch (Exception exp)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(exp.Message);
                }
               
                Console.Write(Environment.NewLine);
            }
        }
        public static void MethBox(string stroka,double firstArg, double secongArg)
        {
            /////////*******Finding the sign of the operation*******\\\\\\\\\\\
            char[] signs = { '+', '-', '*', '/' };
            string[] operands = stroka.Split(signs);
            char sign = stroka[operands[0].Length];
            
            switch (sign)
            {
                case '+':
                    stroka += new ClassForDelMeth().myDelegate1(firstArg, secongArg).ToString();
                    break;
                case '-':
                    stroka += new ClassForDelMeth().myDelegate2(firstArg, secongArg).ToString();
                    break;
                case '*':
                    stroka += new ClassForDelMeth().myDelegate3(firstArg, secongArg).ToString();
                    break;
                case '/':
                    if (secongArg != 0)
                    {
                        stroka += new ClassForDelMeth().myDelegate4(firstArg, secongArg).ToString();
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not possible ");
                        break;
                    }
                    break;
            }
            Console.WriteLine(stroka);
        }
    }
    public class ClassForDelMeth
    {
        public delegate int MyDelegate(double firstArg, double secondArg);

                      //////******lambda operators******\\\\\\\
        public MyDelegate myDelegate1 = (double x, double y) => { return (Convert.ToInt32(x+y));};
        public MyDelegate myDelegate2 = (double x, double y) => { return (Convert.ToInt32(x-y));};
        public MyDelegate myDelegate3 = (double x, double y) => { return (Convert.ToInt32(x*y));};
        public MyDelegate myDelegate4 = (double x, double y) => { return (Convert.ToInt32(x/y));};
    }
}
