using CustomerTrainingApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Puts the Heroku connection string in the correct format to be used by Npgsql
static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
{
    var databaseUri = new Uri(databaseUrl);
    var userInfo = databaseUri.UserInfo.Split(':');
    return $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.LocalPath.Substring(1)};User Id={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=True;";
}


// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString;
// DATABASE_URL provided by Heroku is stored locally in my environment table
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (databaseUrl != null)
{
    connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);
}
else
{
    connectionString = builder.Configuration.GetConnectionString("TrainingDB");
}
builder.Services.AddDbContext<CustomerTrainingDataContext>(o => o.UseNpgsql(connectionString));


// Allows any domain to be able to send http requests. Change in the future to only allow localhost:3000 to guard against security vulnerabilities. 
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