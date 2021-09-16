namespace Stock.Inventario.Repositories.UnitOfWork
{

    using Stock.Inventario.Entities.Context;
    using Stock.Inventario.Entities.Entities;
    using Stock.Inventario.Repositories.Interface;
    using System;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Product> _productRepository;
       

        private readonly StockDbContext _stockDBContext;

        private bool disposed;

        public UnitOfWork(StockDbContext disneyDBContext)
        {
            _stockDBContext = disneyDBContext;
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository ??= new GenericRepository<Product>(_stockDBContext);
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveAsync()
        {
            return await _stockDBContext.SaveChangesAsync() > 0 ;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _stockDBContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
