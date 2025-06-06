using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SkillMatrixPro.Infrastructure
{
    public static class DbContextConfigurationHelper
    {
        /// <summary>
        /// Erstellt eine DbContextOptions-Instanz für <see cref="SkmProDbContext"/> auf Basis der appsettings.json.
        /// </summary>
        /// <param name="basePath">Pfad zur ASP.NET Core-Anwendung (typischerweise das Startup-Projekt).</param>
        /// <returns>Fertige Optionen für die Verwendung im DbContext.</returns>
        public static DbContextOptions<SkmProDbContext> BuildOptions(string basePath)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SkmProDbContext>();
            var connString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connString);
            return optionsBuilder.Options;
        }
    }
}
