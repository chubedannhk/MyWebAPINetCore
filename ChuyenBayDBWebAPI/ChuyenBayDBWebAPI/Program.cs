
using ChuyenBayDBWebAPI.Converters;
using ChuyenBayDBWebAPI.Models;
using ChuyenBayDBWebAPI.Service;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
//======
builder.Services.AddCors();

// AddJsonOptions(...) : dung de khai bao gi...
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});
// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddScoped<ChuyenBayService, ChuyenBayServiceImpl>();
builder.Services.AddScoped<VeService, VeServiceImpl>();

var app = builder.Build();
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
