using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class SystemContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
