using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DAL.DataBase
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContextDLA>
    {
        public DbContextDLA CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configFilePath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"appsettings.json not found at:\n{configFilePath}");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Connection string 'DbCon' is missing or empty in appsettings.json.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<DbContextDLA>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DbContextDLA(optionsBuilder.Options);
        }
    }
}
