using Microsoft.EntityFrameworkCore;
using SkillMatrixPro.Domain.Entities;

namespace SkillMatrixPro.Infrastructure
{
    public class SkmProDbContext(DbContextOptions<SkmProDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeSkillTarget> EmployeeSkillTargets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkmProDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeSkill>(es =>
            {
                es.HasKey(e => new { e.EmployeeId, e.SkillId });

                es.HasOne(e => e.Employee)
                    .WithMany(e => e.Skills)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                es.HasOne(e => e.Skill)
                    .WithMany(s => s.EmployeeSkills)
                    .HasForeignKey(e => e.SkillId)
                    .OnDelete(DeleteBehavior.Cascade);

                es.OwnsOne(e => e.Level, lb =>
                {
                    lb.Property(l => l.Value).HasColumnName("SkillLevelValue");
                });
            });

            modelBuilder.Entity<EmployeeProject>(ep =>
            {
                ep.HasKey(e => new { e.EmployeeId, e.ProjectId });

                ep.HasOne(e => e.Employee)
                    .WithMany()
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                ep.HasOne(e => e.Project)
                    .WithMany()
                    .HasForeignKey(e => e.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
