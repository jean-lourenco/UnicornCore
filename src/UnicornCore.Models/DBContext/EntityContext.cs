using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Models.Infrastructure;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Models.DBContext
{
    public class EntityContext<T> : IDBContext<T> where T : class, IEntity
    {
        private UnicornDBContext _ctx;
        private DbSet<T> _set;

        public EntityContext(UnicornDBContext ctx)
        {
            _ctx = ctx;
            _set = ctx.Set<T>();
        }

        public async Task AddAsync(T entity, bool commit = false)
        {
            try
            {
                _set.Add(entity);

                if (commit)
                    await _ctx.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
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
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.AsNoTracking();
        }

        public async Task RemoveAsync(long id, bool commit = false)
        {
            try
            {
                _set.Remove(Find(id));

                if (commit)
                    await _ctx.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(T entity, bool commit = false)
        {
            try
            {
                _set.Update(entity);

                if (commit)
                    await _ctx.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}