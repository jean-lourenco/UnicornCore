using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DatabaseEntity;
using UnicornCore.Models.Interfaces;
using UnicornCore.Services.BaseService;

namespace UnicornCore.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IDBContext<Person> repo) : base(repo)
        {
        }
    }
}