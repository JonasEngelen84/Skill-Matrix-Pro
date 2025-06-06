using Microsoft.EntityFrameworkCore.Design;

namespace SkillMatrixPro.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SkmProDbContext>
    {
        /// <inheritdoc />
        public SkmProDbContext CreateDbContext(string[] args)
        {
            // Basisverzeichnis der ASP.NET Core-Anwendung (für Zugriff auf appsettings.json)
            var basePath = Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory,
            "..\\..\\..\\..\\SkillMatrixPro.Web"));

            var options = DbContextConfigurationHelper.BuildOptions(basePath);

            return new SkmProDbContext(options);
        }
    }
}
