using Notes.Infrastrunture.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Notes.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
