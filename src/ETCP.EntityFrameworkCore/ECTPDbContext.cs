using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ETCP.EntityFrameworkCore
{
    [ConnectionString]
    public class ETCPDbContext : AbpDbContext<ETCPDbContext>
    {
        public ETCPDbContext(DbContextOptions<ETCPDbContext> options) : base(options)
        {
        }

        #region DbSet


        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}