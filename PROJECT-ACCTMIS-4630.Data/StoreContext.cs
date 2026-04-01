using PROJECT_ACCTMIS_4630.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using PROJECT_ACCTMIS_4630.Domain.Orders;

namespace PROJECT_ACCTMIS_4630.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}