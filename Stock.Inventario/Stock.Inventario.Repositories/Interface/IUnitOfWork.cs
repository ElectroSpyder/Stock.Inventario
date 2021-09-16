namespace Stock.Inventario.Repositories.UnitOfWork
{
    using Stock.Inventario.Entities.Entities;
    using Stock.Inventario.Repositories.Interface;
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }

        Task<bool> SaveAsync();
    }
}
