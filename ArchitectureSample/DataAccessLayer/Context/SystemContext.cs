using CoreLayer.Extensions;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContextExtension
    {
        public SystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDomainActivityStatusHistory> ProjectActivityStatusHistories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ValidationRule> ValidationRules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Domain>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ProjectDomainActivityStatusHistory>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Permission>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Project>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<RolePermission>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserRole>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ValidationRule>().HasQueryFilter(x => !x.IsDeleted).HasIndex(x => x.ValidatorName);

        }



    }
}
