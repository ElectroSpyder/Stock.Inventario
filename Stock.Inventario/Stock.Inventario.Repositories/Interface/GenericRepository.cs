namespace Stock.Inventario.Repositories.Interface
{
    using Microsoft.EntityFrameworkCore;
    using Stock.Inventario.Entities.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StockDbContext _dBContext;
        //private readonly DbSet<T> _dbSet;

        public GenericRepository(StockDbContext dBContext)
        {
            _dBContext = dBContext;
            //_dbSet = _dBContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
             await _dBContext.Set<T>().AddAsync(entity);
            return true;
          
           // return result.IsKeySet;
        }

        public void Update(T entity)
        {           
              _dBContext.Entry(entity).State = EntityState.Modified;
            
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dBContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

             _dBContext.Set<T>().Remove(entity);
            //await _dBContext.SaveChangesAsync();
            return true;
            ;
        }

        public async Task<T> Get(int id)
        {
            return await _dBContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dBContext.Set<T>().ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllByFunc(Expression<Func<T, bool>> filter, string order = null)
        {
            if (filter == null) return null;
            if (order == null) order = "ASC";
            if (order.ToUpper().Trim() == "DESC")
            {
                var result = await _dBContext.Set<T>().Where(filter).OrderByDescending(filter).ToListAsync();
                return result.AsQueryable();
            }

            return _dBContext.Set<T>().Where(filter).OrderBy(filter).AsQueryable();
        }

        public async Task<T> GetSingleByFunc(Expression<Func<T, bool>> filter, string order = null)
        {
            if (filter == null) return null;
            if (order == null) order = "ASC";
            if (order.ToUpper().Trim() == "DESC")
            {
                var result = await _dBContext.Set<T>().Where(filter).OrderByDescending(filter).FirstAsync();
                return result;
            }

            return await _dBContext.Set<T>().Where(filter).OrderBy(filter).FirstAsync();
        }


    }
}
