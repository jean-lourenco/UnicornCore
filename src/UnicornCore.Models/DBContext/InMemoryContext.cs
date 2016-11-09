using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Models.DBContext
{
    public class InMemoryContext<T> : IDBContext<T> where T : class, IEntity
    {
        private ConcurrentDictionary<long, T> _db = new ConcurrentDictionary<long, T>();

        private long NextId => (_db.Count() > 0 ? _db.Keys.Max() : 0) + 1;

        public Task AddAsync(T entity, bool commit = false)
        {
            entity.Id = NextId;
            _db.TryAdd(entity.Id, entity);

            return Task.FromResult<object>(null);
        }

        public bool Exists(T entity)
        {
            return Find(entity.Id) != null;
        }

        public bool Exists(long id)
        {
            return Find(id) != null;
        }

        public T Find(long id)
        {
            return _db.SingleOrDefault(kv => kv.Key == id).Value;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Values;
        }

        public Task RemoveAsync(long id, bool commit = false)
        {
            T temp;

            _db.TryRemove(id, out temp);

            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(T entity, bool commit = false)
        {
            _db[entity.Id] = entity;

            return Task.FromResult<object>(null);
        }

        public Task SaveChangesAsync()
        {
            return Task.FromResult<object>(null);
        }
    }
}