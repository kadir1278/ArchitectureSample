using CoreLayer.DataAccess.Constants;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using DataAccessLayer.Migrations;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<ValidationRule> ValidationRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ScriptEncryptAndDecrypt();
            modelBuilder.Entity<ValidationRule>().HasQueryFilter(x => !x.IsDeleted).HasIndex(x => x.ValidatorName);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);

        }

    }
}
