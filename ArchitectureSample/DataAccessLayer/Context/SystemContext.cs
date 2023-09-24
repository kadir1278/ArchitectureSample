using CoreLayer.Helper;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.GetSqlConnectionString());
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
