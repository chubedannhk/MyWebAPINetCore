using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoSession2WebAPI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class Log1Middleware
{
    private readonly RequestDelegate _next;

    public Log1Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        Debug.WriteLine("Date time: "+ DateTime.Now.ToString("dd/MM/yyyy"));
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class Log1MiddlewareExtensions
{
    public static IApplicationBuilder UseLog1Middleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Log1Middleware>();
    }
}
