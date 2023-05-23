
using DemoSession2_MVC_PayPal.Models;
using DemoSession2_MVC_PayPal.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();


// doc chuoi ket noi ra va ket noi db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

//
builder.Services.AddScoped<ProductService, ProductServiceImpl>();

//


// add để bk đang cần dùng controllers vs view

builder.Services.AddControllersWithViews();

//=======
var app = builder.Build();
// khai bao de su dung session


// đi vào fodder www để lấy hình ảnh
app.UseStaticFiles();
app.UseSession();
//================================
//app.MapControllerRoute(name: "default", pattern: "{controller=demo}/{action=index}");
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.Run();
