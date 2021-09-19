namespace Stock.Inventario.Repositories.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Add(T entity);
        void Update(T entity);
        Task<bool> Delete(int id);
        Task<IQueryable<T>> GetAllByFunc(Expression<Func<T, bool>> filter, string order = null);
        Task<T> GetSingleByFunc(Expression<Func<T, bool>> filter, string order = null);
    }
}
