using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Services.BaseService
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, IEntity
    {
        protected IRepo<T> _db { get; }

        public BaseService(IRepo<T> db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
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

        public async Task RemoveAsync(long id)
        {
            await _db.RemoveAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _db.UpdateAsync(entity);
        }
    }
}