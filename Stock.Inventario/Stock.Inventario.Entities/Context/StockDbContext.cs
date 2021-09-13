using Microsoft.EntityFrameworkCore;
using Stock.Inventario.Entities.Entities;

namespace Stock.Inventario.Entities.Context
{
    public class StockDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=Stock.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
