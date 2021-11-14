using CLCOM_SeminarRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CLCOM_SeminarRestApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>(e =>
            {
                e.ToTable("Students");
                e.HasKey(s => s.Id);
                e.Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(s => s.FirstName).IsRequired().HasMaxLength(128);
                e.Property(s => s.LastName).IsRequired().HasMaxLength(128);
                e.Property(s => s.Program).HasMaxLength(8);
            });
        }
    }
}
