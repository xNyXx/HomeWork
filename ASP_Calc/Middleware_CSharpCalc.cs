using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace ASP_Calc
{
    public class Middleware_CSharpCalc
    {
        private readonly RequestDelegate _next;

        public Middleware_CSharpCalc(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            /*if (string.IsNullOrWhiteSpace(context.Request.QueryString.ToString()))
                await context.Response.WriteAsync("ERROR 404");*/

            var query_string = context.Request.QueryString.ToString();
            char operation = ' ';
            var found = false;
            foreach (var chr in query_string)
            {
                switch (chr)
                {
                    case '+':
                        operation = chr;
                        found = true;
                        break;
                    case '-':
                        operation = chr;
                        found = true;
                        break;
                    case '*':
                        operation = chr;
                        found = true;
                        break;
                    case '/':
                        operation = chr;
                        found = true;
                        break;
                }
                if (found)
                    break;
            }
            if(!(operation == ' '))
            {
                var nums = query_string.Split(query_string[query_string.IndexOf(operation)]);
                var str_bld = new StringBuilder();
                var loc_hst_remove = "localhost:5001";
                var nums0 = nums[0].Remove(nums[0].IndexOf(loc_hst_remove), loc_hst_remove.Length);
                foreach (var s in nums0)
                {
                    if (char.IsDigit(s))
                        str_bld.Append(s);
                }

                int num1 = int.Parse(str_bld.ToString());
                str_bld.Clear();
                foreach (var s in nums[1])
                {
                    if (char.IsDigit(s))
                        str_bld.Append(s);
                }

                int num2 = int.Parse(str_bld.ToString());
                int result = Calc.Calculator.Calculate(num1, operation.ToString(), num2);    //Вот здесь результат
                context.Response.Headers.Add("result", result.ToString());
                /*context.Response.Headers.Add("result", result.ToString());
                context.Response.ContentType = result.ToString();*/
            }            
            await _next(context);
        }
    }
}