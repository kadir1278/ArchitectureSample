using CoreLayer.Extensions;
using CoreLayer.Helper;
using EntityLayer.Entity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserBuilder
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.ScriptEncryptAndDecrypt();
            #endregion
        }

    }
}
