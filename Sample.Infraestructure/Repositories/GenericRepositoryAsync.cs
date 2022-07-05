using Microsoft.EntityFrameworkCore;
using Sample.Application.Interfaces;
using Sample.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sample.Infraestructure.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entitySet;

        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            entitySet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            entitySet.Add(entity);
            await Save();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            T entity = await entitySet.FindAsync(id);
            entitySet.Remove(entity);
            await Save();
            return entity;
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
            => await entitySet.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAll()
            => await entitySet.ToListAsync();

        public async Task<T> GetbyId(int? id)
            => await entitySet.FindAsync(id);

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
             => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task Update(T entity)
        {
            entitySet.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<T>> GetAll()
        //    => await entitySet.ToListAsync();
        //public async Task<T> Get(string id)
        //    => await entitySet.FindAsync(id);
        //public async Task<T> Find(Expression<Func<T, bool>> predicate)
        //    => await entitySet.FirstOrDefaultAsync(predicate);
        //public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        //    => await _context.Set<T>().Where(predicate).ToListAsync();
        //public void Add(T entity)
        //{
        //    entitySet.Add(entity);
        //}
        //public void Delete(T entity)
        //{
        //    entitySet.Remove(entity);
        //}
        //public void Update(T entity)
        //{
        //    entitySet.Update(entity);
        //}
    }
}
