using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RepositoryDepartamentos>();

//string connectionString = builder.Configuration.GetConnectionString("MariaDB");

//builder.Services.AddDbContext<DepartamentosContext>(options => options.UseNpgsql(connectionString));
string connectionString = builder.Configuration.GetConnectionString("MariaDB");

builder.Services.AddDbContext<DepartamentosContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



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
