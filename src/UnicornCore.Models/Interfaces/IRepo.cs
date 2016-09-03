using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnicornCore.Models.Interfaces
{
    public interface IRepo<T> where T : class, IEntity
    {
        Task AddAsync(T entity);

        Task RemoveAsync(long id);

        Task UpdateAsync(T entity);

        T Find(long id);

        IEnumerable<T> GetAll();

        bool Exists(long id);

        bool Exists(T entity);
    }
}