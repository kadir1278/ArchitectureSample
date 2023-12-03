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
        public DbSet<Company> Companies { get; set; }
        public DbSet<ValidationRule> ValidationRules { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ScriptEncryptAndDecrypt();
            modelBuilder.Entity<ValidationRule>().HasQueryFilter(x => !x.IsDeleted).HasIndex(x => x.ValidatorName);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<RolePermission>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Permission>().HasQueryFilter(x => !x.IsDeleted);

        }

    }
}
