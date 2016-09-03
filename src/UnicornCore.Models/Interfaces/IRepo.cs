using System.Collections.Generic;

namespace UnicornCore.Models.Interfaces
{
    public interface IRepo<T> where T : class, IEntity
    {
        void Add(T entity);

        void Remove(long id);

        void Update(T entity);

        T Find(long id);

        IEnumerable<T> GetAll();

        bool Exists(long id);

        bool Exists(T entity);
    }
}