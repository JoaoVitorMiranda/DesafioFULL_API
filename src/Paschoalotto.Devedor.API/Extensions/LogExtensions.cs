using Microsoft.AspNetCore.Builder;
using Paschoalotto.Devedor.API.Middlewares;

namespace Paschoalotto.Devedor.API.Extensions
{
    public static class LogExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
