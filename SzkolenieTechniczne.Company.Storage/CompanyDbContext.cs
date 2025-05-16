using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage
{
    public class CompanyDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ContactTypeTranslation> ContactTypeTranslations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobPositionTranslation> JobPositionTranslations { get; set; }

        public CompanyDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=company-dev;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Company"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobPosition>()
                .HasMany<JobPositionTranslation>()
                .WithOne(t => t.JobPosition)
                .HasForeignKey(t => t.JobPositionId);

            modelBuilder.Entity<ContactType>()
                .HasMany(ct => ct.Translations)
                .WithOne(t => t.ContactType)
                .HasForeignKey(t => t.ContactTypeId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Translations)
                .WithOne()
                .HasForeignKey(t => t.CountryId);
        }
    }
} 