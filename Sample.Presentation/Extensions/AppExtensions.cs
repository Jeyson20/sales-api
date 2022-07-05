using Microsoft.AspNetCore.Builder;
using Sample.Presentation.Middlewares;

namespace Sample.Presentation.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
