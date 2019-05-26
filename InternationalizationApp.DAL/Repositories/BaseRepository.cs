using InternationalizationApp.DAL;
using System.Collections.Generic;
using System.Data.Entity;

namespace LearnWithMentorDAL.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly Context Context;
        public BaseRepository(Context context)
        {
            Context = context;
        }

        public async System.Threading.Tasks.Task<IEnumerable<T>> GetAll()
        {
            return Context.Set<T>();
        }

        public async System.Threading.Tasks.Task AddAsync(T item)
        {
            Context.Set<T>().Add(item);
        }

        public async System.Threading.Tasks.Task UpdateAsync(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public async System.Threading.Tasks.Task RemoveAsync(T item)
        {
            Context.Set<T>().Remove(item);
        }
    }
}