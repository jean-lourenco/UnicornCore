using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        public void Add(T entity)
        {
            _db.Add(entity);
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

        public void Remove(long id)
        {
            _db.Remove(id);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}