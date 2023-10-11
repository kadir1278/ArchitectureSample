using CoreLayer.Extensions;
using CoreLayer.Helper;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        protected IHttpContextAccessor HttpContextAccessor { get; }
        public SystemContext(DbContextOptions dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ScriptEncryptAndDecrypt();

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted && x.ProjectOwner.Domain.Contains(HttpContextAccessor.HttpContext.Request.Host.ToString()));
            modelBuilder.Entity<ProjectOwner>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}
