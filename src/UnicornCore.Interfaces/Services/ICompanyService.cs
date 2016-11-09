using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Models.DatabaseEntity;

namespace UnicornCore.Interfaces.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        IEnumerable<Person> GetRetiredEmployees(Company company);
        Task AddEmployeeAsync(Company company, Person person, bool commit = false);
    }
}