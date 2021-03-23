using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TabletopRpg.Core.Domain;

namespace TabletopRpg.DataAccess.Contexts
{
    public class TabletopRpgDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public TabletopRpgDbContext(DbContextOptions<TabletopRpgDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}