using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Bases
{
    public class GenericRepository<T> :IGenericRepository<T> where T :class
    {

      

        protected readonly ApplicationDBContext _dbContext;

      

    
        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public virtual async Task<T> GetByIdAsync(int id)
        {

            return await _dbContext.Set<T>().FindAsync(id);
        }



        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {

            foreach (var item in entities)
            {
                await _dbContext.Set<T>().AddAsync(item);
            }

            await _dbContext.SaveChangesAsync();

        }


        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }


        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }



        //public ApplicationDBContext BeginTransaction()
        //{


        //    return _dbContext.Database.BeginTransaction();
        //}


        public void Commit()
        {
            _dbContext.Database.CommitTransaction();

        }


        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();

        }

      

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }





    }
}
