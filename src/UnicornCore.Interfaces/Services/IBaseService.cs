using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Interfaces.Services
{
    public interface IBaseService<T> where T : class, IEntity
    {
        Task AddAsync(T entity, bool commit = false);

        Task RemoveAsync(long id, bool commit = false);

        Task UpdateAsync(T entity, bool commit = false);

        T Find(long id);

        IEnumerable<T> GetAll();

        bool Exists(long id);

        bool Exists(T entity);

        Task SaveChangesAsync();
    }
}