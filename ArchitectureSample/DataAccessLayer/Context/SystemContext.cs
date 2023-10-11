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
        private string _domain { get; set; }
        public SystemContext(DbContextOptions dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
        {
            this.HttpContextAccessor = httpContextAccessor;
            _domain = HttpContextAccessor.HttpContext.Request.Host.ToString();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ScriptEncryptAndDecrypt();


            modelBuilder.Entity<User>(entity =>
            {
                if (_domain == "localhost:7081")
                    entity = entity.HasQueryFilter(e => !e.IsDeleted);
                else
                    entity = entity.HasQueryFilter(e => !e.IsDeleted && e.ProjectOwner.Domain == _domain);
            });

            modelBuilder.Entity<ProjectOwner>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}
