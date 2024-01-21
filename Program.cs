using Microsoft.EntityFrameworkCore;
using versta24.Data;
using versta24.Services;

var builder = WebApplication.CreateBuilder(args);
var DbConnectionString = builder.Configuration.GetConnectionString("Database") ?? 
    throw new NullReferenceException("Connection string with name \"Database\" not found");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VerstaDbContext>(options => options.UseNpgsql(DbConnectionString));
builder.Services.AddSingleton<NumberService, NumberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
