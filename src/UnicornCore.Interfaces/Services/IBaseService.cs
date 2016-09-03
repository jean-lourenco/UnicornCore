using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Interfaces.Services
{
    public interface IBaseService<T> where T : class, IEntity
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