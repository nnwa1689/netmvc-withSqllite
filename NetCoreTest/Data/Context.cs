using Microsoft.EntityFrameworkCore;

namespace NetCoreTest.Data
{
    public class Context : DbContext
    {
        public Context(
            DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<NetCoreTest.Models.Article> Article { get; set; }
    }
}