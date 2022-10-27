using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class , IBaseEntity
    {
        private readonly AppDbContext db;

        public BaseRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await db.Set<T>().AnyAsync(expression);
        }

        public async Task<bool> Create(T entity)
        {
            db.Set<T>().Add(entity);
            return await db.SaveChangesAsync() > 0;                     
        }

        public void Delete(T entity)
        {
            entity.Status = false;
            db.Set<T>().Update(entity);
            db.SaveChanges();
        }
        public async Task<List<T>> GetAllWhere(Expression<Func<T, bool>> expression)
        {
            return await db.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = db.Set<T>();
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null) return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = db.Set<T>();
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null) return await orderBy(query).Select(selector).ToListAsync();
            else return await query.Select(selector).ToListAsync();
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await db.Set<T>().FirstOrDefaultAsync(expression);
        }

        public bool Update(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChanges() > 0;
        }
    }
}
