using System;
using System.Text;
namespace Calc
{
    public static class Text_Parser
    {
        public static string[] Parse(string query_string)
        {
            var present = query_string.IndexOfAny(new char[] {'+', '-', '/', '*'});
            if (present != 1)
                throw new ArgumentException("Invalid_Operation");
            var num1 = query_string.Substring(0,present);
            var num2 = query_string.Substring(present + 1, query_string.Length-(present+1));
            var operation = query_string[present].ToString();
            return new String [] {num1, operation, num2};
        }
    }
}