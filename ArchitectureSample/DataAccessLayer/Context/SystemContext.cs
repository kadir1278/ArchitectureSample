using CoreLayer.DataAccess.Constants;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        private string _domain { get; set; }
        private string _cultureInfo { get; set; }
        private readonly HttpContext _context;
        public SystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _context = HttpContextHelper.GetHttpContext();
            if (_context is not null)
            {
                _domain = _context.Request.Host.ToString().ToLower();
                _cultureInfo = String.IsNullOrEmpty(_context.Request.Cookies["CultureInfo"]) ? CultureInfoHelper.Turkish : _context.Request.Cookies["CultureInfo"];
            }
            else
            {
                _cultureInfo = CultureInfoHelper.Turkish;
            }
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
