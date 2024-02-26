using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JoesPizza.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JoesPizzaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JoesPizzaContext") ?? throw new InvalidOperationException("Connection string 'JoesPizzaContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizzas}/{action=Index}/{id?}");

app.Run();
