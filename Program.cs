// Program.cs
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database connection
// Make sure to replace "YourServerName" with your actual SQL Server name
// and "LibraryManagementSystemDB" with your database name.
// For local SQL Server Express, it might be "Server=(localdb)\\mssqllocaldb;Database=LibraryManagementSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true"
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       "Server=SAIFUL_ISLAM;Database=LibraryManagementSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();




// ... rest of Program.cs ...

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

app.UseAuthorization(); // If you implement authentication later, this will be crucial

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
