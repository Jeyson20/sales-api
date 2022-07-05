using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sample.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        //Busca una coleccion dependiendo la expresion
        Task<IEnumerable<T>> GetWhere(Expression<Func<T,bool>> predicate);
        Task<T> GetbyId(int? id);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task<T> Delete(int id);
    }
}
