using System.Collections.Generic;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Interfaces.Services
{
    public interface IBaseService<T> where T : class, IEntity
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