
using DemoSession2WebAPI.Converters;
using DemoSession2WebAPI.Middlewares;
using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
//======
builder.Services.AddCors();
//===========
// AddJsonOptions(...) : dung de khai bao gi...
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});
// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
//
builder.Services.AddScoped<ProductSerivice, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();

var app = builder.Build();

// dua middleware vao program
//app.UseMiddleware<BasicAuthMiddleware>();
//app.UseMiddleware<Log1Middleware>();
//app.UseMiddleware<SecurityMiddleware>();
//app.UseMiddleware<Log2Middleware>();
//app.UseMiddleware<Log3Middleware>();

//lay addcors xuong su dung
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseStaticFiles();
app.MapControllers();

app.Run();
