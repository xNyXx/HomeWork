using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace ASP_Calc
{
    public class Calc_MiddleWare
    {
        private readonly RequestDelegate _next;

        public Calc_MiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        
            public async Task InvokeAsync(HttpContext context)
            {
                var issue = context.Request.Query["issue"];
                var result = Calc.Calculator.Calculate(issue);
                context.Response.Headers.Add("calc_result",result.ToString());
                await _next(context);
            }
        }
    }