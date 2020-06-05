using System;
using System.Runtime.InteropServices;


namespace lab4_2
{
    class Program
    {
        [DllImport("BlankDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double sum(double num1, double num2);

        [DllImport("BlankDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double dif(double num1, double num2);

        [DllImport("BlankDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double mult(double num1, double num2);

        [DllImport("BlankDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double div(double num1, double num2);

        static void Main(string[] args)
        {
            int choice = 0;
            Console.Write("Enter the first number : ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the second number : ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nChoose an action : \n" +
                "1)Addition(+)\n2)Substraction(-)\n3)Multiplying(*)\n4)Dividing(/)");

            while (choice <= 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Amount : " + sum(num1, num2));
                    break;

                case 2:
                    Console.WriteLine("Difference : " + dif(num1, num2));
                    break;

                case 3:
                    Console.WriteLine("Multiply : " + mult(num1, num2));
                    break;

                case 4:
                    Console.WriteLine("Divide : " + div(num1, num2));
                    break;
                default:
                    Console.WriteLine("There is no such operation, try again ");
                    break;
            }
            Console.WriteLine("Press any to exit...");
            Console.ReadKey();
        }
    }

}

