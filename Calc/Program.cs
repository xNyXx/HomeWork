﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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