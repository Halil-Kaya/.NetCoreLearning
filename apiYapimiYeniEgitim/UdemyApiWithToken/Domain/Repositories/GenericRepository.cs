using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly UdemyApiWithTokenDBContext _dbContext;
        private DbSet<T> table = null;

        public GenericRepository(UdemyApiWithTokenDBContext context)
        {  
            this._dbContext = context;
            table = this._dbContext.Set<T>();
            
        }

        public async Task Add(T entry)
        {
            await table.AddAsync(entry);

        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await table.CountAsync(predicate);
        }

        public async Task Delete(int id)
        {
            T existEntitiy = await GetById(id); 
            table.Remove(existEntitiy);
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public void Update(T entry)
        {
            this._dbContext.Entry(entry).State = EntityState.Modified;
        }
    }
}