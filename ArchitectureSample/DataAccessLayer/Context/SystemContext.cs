using CoreLayer.DataAccess.Constants;
using CoreLayer.Extensions;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        private string _domain { get; set; }
        private string _cultureInfo { get; set; }
        public SystemContext(DbContextOptions dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
        {
            _domain = httpContextAccessor.HttpContext.Request.Host.ToString().ToLower();
            _cultureInfo = String.IsNullOrEmpty(httpContextAccessor.HttpContext.Request.Cookies["CultureInfo"]) ?
                                                                                                        CultureInfoHelper.Turkish :
                                                                                                        httpContextAccessor.HttpContext.Request.Cookies["CultureInfo"];
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ScriptEncryptAndDecrypt();


            modelBuilder.Entity<User>(entity =>
            {
                if (_domain == "localhost:7081")
                    entity = entity.HasQueryFilter(e => !e.IsDeleted && e.CultureInfo == _cultureInfo);
                else
                    entity = entity.HasQueryFilter(e => !e.IsDeleted && e.ProjectOwner.Domain == _domain && e.CultureInfo == _cultureInfo);
            });

            modelBuilder.Entity<ProjectOwner>().HasQueryFilter(x => !x.IsDeleted && x.CultureInfo == _cultureInfo);
            modelBuilder.Entity<ProjectOwner>().HasIndex(x => x.Domain);
        }

    }
}
