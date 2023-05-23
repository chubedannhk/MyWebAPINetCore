using DemoSession2WebAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession2WebAPI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
       
    }

    public async Task Invoke(HttpContext httpContext, AccountService accountService)
    {
        var authorization = httpContext.Request.Headers.Authorization.ToString();
        if (!string.IsNullOrEmpty(authorization))
        {
            Debug.WriteLine(authorization);
            // cac chuoi Basic thua o phia truoc di
            authorization = authorization.Replace("Basic ", "");
             // sau do debug ra lai
            Debug.WriteLine(authorization);
            // convert lai username va password
            var bytes = Convert.FromBase64String(authorization);
            // sau do tach user va password ra nho vao Split
            var usernamePassword = Encoding.GetEncoding("UTF-8").GetString(bytes).Split(new char[] {':'});
            //Debug.WriteLine("UsernamePassword: " + usernamePassword);
            // sau do in username va password ra
            var username = usernamePassword[0];
            var password = usernamePassword[1];
            Debug.WriteLine("Username: "+username);
            Debug.WriteLine("Password: "+password);
            if(accountService.Login(username,password))
            {
                await _next(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;return;
            }
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; return;
        }
       
        //return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class BasicAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BasicAuthMiddleware>();
    }
}
