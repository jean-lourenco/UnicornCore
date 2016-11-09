using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DatabaseEntity;
using UnicornCore.Models.Interfaces;
using UnicornCore.Services.BaseService;

namespace UnicornCore.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IDBContext<Company> ctx) : base(ctx)
        {
        }

        public IEnumerable<Person> GetRetiredEmployees(Company company)
        {
            return _db.Find(company.Id).Employees.Where(p => p.Birthday.AddYears(60) < DateTime.Now);
        }

        public async Task AddEmployeeAsync(Company company, Person person, bool commit = false)
        {
            company.Employees.Add(person);

            if (commit)
                await _db.SaveChangesAsync();
        }
    }
}