using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace SharpLab7
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter the numerator & the denumerator in the first expresion");
            RationalNumber x = new RationalNumber(int.Parse(ReadLine()), int.Parse(ReadLine()));
            WriteLine("Enter the numerator & the denumerator in the second expresion");
            RationalNumber y = new RationalNumber(int.Parse(ReadLine()), int.Parse(ReadLine()));
            WriteLine("int: \nx = {0}\ny = {1}", (int)x, (int)y);
            WriteLine("float: \nx = {0}\ny = {1}", (float)x, (float)y);
            WriteLine("double: \nx = {0}\ny = {1}", (double)x, (double)y);
            WriteLine("RationalNumber: \nx = {0}\ny = {1}", x, y);
            WriteLine("Amount: " + (x + y).ToString() + "\nDifference: " + (x - y).ToString()
                + "\nComposition: " + (x * y).ToString() + "\nPrivate: " + (x / y).ToString());
            ReadKey(true);
        }
    }
}
