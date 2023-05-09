using DemoSession1WebAPI.Converters;
using DemoSession1WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// AddJsonOptions(...) : dung de khai bao gi...
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});

builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
