using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kalum2020_v1.DataContext
{
    public class KalumnDBContext : IDesignTimeDbContextFactory<KalumDB>
    {
        public KalumnDBContext()
        {
        }

        public KalumDB CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            var optionBuilder = new DbContextOptionsBuilder<KalumDB>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new KalumDB(optionBuilder.Options);
        }
    }
}