using Microsoft.AspNetCore.Builder;

namespace ASP_Calc
{
    public static class Middleware_CSharpCalc_Extensions
    {
        public static IApplicationBuilder UseMiddleware_CSharpCalc(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware_CSharpCalc>();
        }
    }
}