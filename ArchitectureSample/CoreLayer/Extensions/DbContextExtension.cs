using CoreLayer.Entity;
using CoreLayer.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CoreLayer.Extensions
{
    public class DbContextExtension : DbContext
    {
        public DbContextExtension(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Audit> Audits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ScriptEncryptAndDecrypt();

            modelBuilder.Entity<Audit>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HttpContext httpContext = HttpContextHelper.GetHttpContext();
            OnBeforeSaveChangesAsync();

            var returnStatus = base.SaveChangesAsync(cancellationToken);

            if (returnStatus.Result == 1) OnSuccessSaveChangesAsync();
            else OnExceptionSaveChangesAsync();

            OnAfterSaveChangesAsync(httpContext);
            return returnStatus;
        }

        private void OnBeforeSaveChangesAsync()
        {

        }
        private void OnAfterSaveChangesAsync(HttpContext httpContext)
        {
            Audits.Add(new Audit()
            {
                TargetTable = "bilmem",
                LogMessage = "Bilmem tablosu için save işlemi bitti",
                Request = JsonSerializer.Serialize(httpContext.Request.Body),
                ContextRequestId = httpContext.Items["RequestId"] != null ? httpContext.Items["RequestId"].ToString() : "İç ağdan gelen istek"

            });
        }
        private void OnExceptionSaveChangesAsync()
        {

        }
        private void OnSuccessSaveChangesAsync()
        {

        }
    }
}
