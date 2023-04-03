using CustomerTrainingApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? builder.Configuration.GetConnectionString("TrainingDB");
builder.Services.AddDbContext<CustomerTrainingDataContext>(o => o.UseNpgsql(connectionString));

//builder.Services.AddDbContext<CustomerTrainingDataContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("TrainingDB"))

//Allows any domain to be able to send http requests. Change in the future to only allow localhost:3000 to guard against security vulnerabilities. 
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));

var app = builder.Build();

// Configure custom logging
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
ILogger logger = loggerFactory.CreateLogger<Program>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    logger.LogInformation("Exception handling enabled");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();