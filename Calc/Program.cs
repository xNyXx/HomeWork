using System;
using System.Diagnostics.CodeAnalysis;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Calculator.GetNubmer();
            var b = Calculator.GetNubmer();
            Console.WriteLine(Calculator.Calculate(a, "+", b));
        }
    }
    
}