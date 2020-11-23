using Microsoft.AspNetCore.Builder;

namespace ASP_Calc
{
    public static class Calc_MiddleWare_Extensions
    {
        public static IApplicationBuilder UseCalc_MiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Calc_MiddleWare>();
        }
    }
}