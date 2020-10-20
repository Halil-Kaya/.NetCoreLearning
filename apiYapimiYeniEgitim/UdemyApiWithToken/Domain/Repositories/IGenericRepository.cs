using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.Repositories
{
    public interface IGenericRepository<T> where T:class 
    {

        Task<T> GetById(int id);
        
        Task<IEnumerable<T>> GetWhere(Expression<Func<T,bool>> predicate);

        Task<int> CountWhere(Expression<Func<T,bool>> predicate);

        Task Add(T entry);
        void Update(T entry);
        Task Delete(int id);

    }
}