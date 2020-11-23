using System;
using System.Diagnostics.CodeAnalysis;

namespace Calc
{
    public static class Calculator
    {
        public static int GetNubmer()
        {
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        public static int Calculate(int num1, string operation, int num2)
        {
            switch (operation)
            {
                case "+" : return num1 + num2;
                    break;
                case "-" : return num1 - num2;
                    break;
                case "/" :
                    if (num2 == 0) throw new Exception("Zero devision");
                    return num1 / num2;
                    break;
                case "*" : return num1 * num2;
                    break;
                default: throw new ArgumentException("Invalid operation");
            }
        }

        public static int Calculate(string issue)
        {
            var variables = Text_Parser.Parse(issue);
            var num1 = int.Parse(variables[0]);
            var operation = variables[1];
            var num2 = int.Parse(variables[2]);
            switch (operation)
            {
                case "+" : return num1 + num2;
                    break;
                case "-" : return num1 - num2;
                    break;
                case "/" :
                    if (num2 == 0) throw new Exception("Zero devision");
                    return num1 / num2;
                    break;
                case "*" : return num1 * num2;
                    break;
                default: throw new ArgumentException("Invalid operation");
            }
        }
    }
}