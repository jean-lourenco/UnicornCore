using System.Collections.Generic;

namespace UnicornCore.Models.DatabaseEntity
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public IList<Person> Employees { get; set; }
    }
}