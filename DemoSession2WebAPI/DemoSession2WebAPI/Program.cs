
using DemoSession2WebAPI.Converters;
using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

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
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
