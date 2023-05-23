﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace DemoSession2WebAPI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class SecurityMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var status = true;
        if (status)
        {
            await _next(httpContext);
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }
       
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class SecurityMiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecurityMiddleware>();
    }
}
