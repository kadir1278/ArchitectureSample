using CoreLayer.Extensions;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ScriptEncryptAndDecrypt();

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ProjectOwner>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}
