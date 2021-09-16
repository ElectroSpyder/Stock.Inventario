using Microsoft.EntityFrameworkCore;
using Stock.Inventario.Entities.Entities;

namespace Stock.Inventario.Entities.Context
{
    public class StockDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }       

        public StockDbContext(DbContextOptions<StockDbContext> options): base(options)
        {
            
        }

       
    }
}
