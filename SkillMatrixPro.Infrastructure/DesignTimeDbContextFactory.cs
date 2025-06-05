using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SkillMatrixPro.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SkmProDbContext>
    {
        public SkmProDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine("CurrentDirectory: " + Directory.GetCurrentDirectory());

            // Ermittle den absoluten Pfad zur Web-Projektmappe
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\SkillMatrixPro.Web"));

            Console.WriteLine($"[DesignTimeDbContextFactory] BasePath: {basePath}");

            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                throw new FileNotFoundException("appsettings.json wurde nicht gefunden im Pfad: " + basePath);
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SkmProDbContext>();
            var connString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine($"[DesignTimeDbContextFactory] ConnectionString: {connString}");

            optionsBuilder.UseSqlServer(connString);

            return new SkmProDbContext(optionsBuilder.Options);
        }
    }
}
