using CustomerTrainingApp.Data.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File is used by Entity Framework tools to create an instance of the DbContext class which is required to perform migrations for my Heroku postgres database
public class CustomerTrainingDataContextFactory : IDesignTimeDbContextFactory<CustomerTrainingDataContext>
{
    public CustomerTrainingDataContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CustomerTrainingApp"))
            .AddJsonFile("appsettings.json");

        var configuration = configurationBuilder.Build();

        string connectionString;
        // DATABASE_URL provided by Heroku is stored locally in my environment table
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

        if (!string.IsNullOrEmpty(databaseUrl))
        {
            connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);
        }
        else
        {
            connectionString = configuration.GetConnectionString("TrainingDB");
        }


        var optionsBuilder = new DbContextOptionsBuilder<CustomerTrainingDataContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new CustomerTrainingDataContext(optionsBuilder.Options);
    }

    // Puts the Heroku connection string in the correct format to be used by Npgsql
    private string ConvertDatabaseUrlToConnectionString(string databaseUrl)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');
        return $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.LocalPath.Substring(1)};User Id={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=True;";
    }
}
