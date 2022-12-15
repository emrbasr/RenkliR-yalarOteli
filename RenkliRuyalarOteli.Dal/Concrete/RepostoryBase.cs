﻿using Microsoft.EntityFrameworkCore;
using RenkliRuyalarOteli.DAL.Abstract;
using RenkliRüyalarOteli.Entities.Context;
using RenkliRüyalarOteli.Entities.Entities.Abstract;
using System.Linq.Expressions;

namespace RenkliRuyalarOteli.DAL.Concrete
{
    public class RepostoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        public SqlDbContext dbContext { get; set; }
        public RepostoryBase()
        {
            dbContext = new SqlDbContext();
        }



        public virtual async Task<int> CreateAsync(T entity)
        {
            //İşi yapmasını asenkron olarak bildiriyoruz
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
            }
            else
            {
                return await dbContext.Set<T>().FirstOrDefaultAsync();
            }
        }

        public virtual async Task<ICollection<T>> RawSqlQuery(T entity, string sql)
        {
            var result = dbContext.Set<T>().FromSqlRaw(sql);

            return await result.ToListAsync();
        }

        public virtual Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }








    }
}
