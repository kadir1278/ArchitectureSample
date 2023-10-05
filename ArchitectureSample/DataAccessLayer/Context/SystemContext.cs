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
            modelBuilder.Entity<User>()
                        .Property(e => e.Username).HasConversion(
                                       e => EncryptionHelper.EncryptPassword(e),
                                       e => EncryptionHelper.DecryptPassword(e));
            modelBuilder.Entity<User>()
                        .Property(e => e.Password).HasConversion(
                                       e => EncryptionHelper.EncryptPassword(e),
                                       e => EncryptionHelper.DecryptPassword(e));
            modelBuilder.Entity<User>()
                        .Property(e => e.Name).HasConversion(
                                       e => EncryptionHelper.EncryptPassword(e),
                                       e => EncryptionHelper.DecryptPassword(e));
            modelBuilder.Entity<User>()
                        .Property(e => e.Surname).HasConversion(
                                       e => EncryptionHelper.EncryptPassword(e),
                                       e => EncryptionHelper.DecryptPassword(e));
            #endregion
        }

    }
}
