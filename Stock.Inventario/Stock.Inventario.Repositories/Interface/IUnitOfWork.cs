namespace DisneyApi.Core.Repositories.UnitOfWork
{
    using DisneyApi.Core.Repositories.GenericRepository;
    using Stock.Inventario.Entities.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }

        Task<bool> SaveAsync();
    }
}
