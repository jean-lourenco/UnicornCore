using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Models.Repo
{
    public class ConcurrentDictionaryRepo<T> : IRepo<T> where T : class, IEntity
    {
        private static ConcurrentDictionary<long, T> _db = new ConcurrentDictionary<long, T>();

        private long NextId { get { return (_db.Count() > 0 ? _db.Keys.Max() : 0) + 1; } }

        public void Add(T entity)
        {
            entity.Id = NextId;
            _db.TryAdd(entity.Id, entity);
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

        public void Remove(long id)
        {
            T temp;

            _db.TryRemove(id, out temp);
        }

        public void Update(T entity)
        {
            _db[entity.Id] = entity;
        }
    }
}