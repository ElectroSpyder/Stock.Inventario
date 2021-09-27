using Microsoft.EntityFrameworkCore;

namespace Stock.Control.Data
{

    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts()
        {
            return new Product[]
            {
            new Product { Id = 1, Name = "SmartWatch DT88 Pro", Description = "Doble malla rosa", Price ="8952,58", Unit =5},
            new Product { Id = 2, Name = "SmartWatch DT88 Pro", Description = "Doble malla negra", Price ="8952,58", Unit =1},
            new Product { Id = 3, Name = "Socks", Description = "Wollen", Price = "8952,58", Unit =2},
            new Product { Id = 4, Name = "Tshirt", Description = "Red", Price = "8952,58", Unit =3},
            };
        }
    }
}
