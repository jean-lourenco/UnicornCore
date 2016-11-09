using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Services.BaseService
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, IEntity
    {
        protected IDBContext<T> _db { get; }

        public BaseService(IDBContext<T> db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity, bool commit = false)
        {
            await _db.AddAsync(entity, commit);
        }

        public bool Exists(T entity)
        {
            return _db.Exists(entity);
        }

        public bool Exists(long id)
        {
            return _db.Exists(id);
        }

        public T Find(long id)
        {
            return _db.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetAll();
        }

        public async Task RemoveAsync(long id, bool commit = false)
        {
            await _db.RemoveAsync(id, commit);
        }

        public async Task UpdateAsync(T entity, bool commit = false)
        {
            await _db.UpdateAsync(entity, commit);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}