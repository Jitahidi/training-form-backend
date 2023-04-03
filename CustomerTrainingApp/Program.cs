using CustomerTrainingApp.Data.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("postgres:npbboblbkypzic:8f3b4b20fe05dbf0c37e771638e16f7e65d011839de7de1992aec584b32af8c3@ec2-52-1-92-133.compute-1.amazonaws.com:5432/d6vvbnu0980brq") ?? builder.Configuration.GetConnectionString("TrainingDB");
builder.Services.AddDbContext<CustomerTrainingDataContext>(o => o.UseNpgsql(connectionString));


//builder.Services.AddDbContext<CustomerTrainingDataContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("TrainingDB"))

//Allows any domain to be able to send http requests. Change in the future to only allow localhost:3000 to guard against security vulnerabilities. 
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();