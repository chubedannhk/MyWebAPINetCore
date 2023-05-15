

using Information_Flight.Converters;
using Information_Flight.Models;
using Information_Flight.Service;
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
builder.Services.AddScoped<ChuyenBayService, ChuyenBayServiceImpl>();
builder.Services.AddScoped<ChiTietService, ChiTietServiceImpl>();
builder.Services.AddScoped<HanhKhachService, HanhKhachServiceImpl>();
builder.Services.AddScoped<VeService, VeServiceImpl>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();