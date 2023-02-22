using Microsoft.AspNetCore.Builder;
using AppShop.Middleware;

namespace AppShop.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder userFileLogging(this IApplicationBuilder app) => app.UseMiddleware<LogMiddleware>();
    }
}
