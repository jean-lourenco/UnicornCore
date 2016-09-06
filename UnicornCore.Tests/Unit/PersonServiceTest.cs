using Autofac;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DatabaseEntity;
using UnicornCore.Tests.Unit.BaseTest;
using Xunit;

namespace UnicornCore.Tests.Unit
{
    public class PersonServiceTest : BaseServiceTest
    {
        public IPersonService _personService { get; set; }

        public PersonServiceTest()
        {
            _personService = Container.Resolve<IPersonService>();
        }

        [Theory]
        [InlineData("Abigail Williams", "1680-07-12")]
        [InlineData("John Hathorne", "1641-08-02")]
        [InlineData("Giles Corey", "1611-09-11")]
        public async Task Persons_Can_Be_Added(string name, string date)
        {
            var person = new Person
            {
                Name = name,
                Birthday = DateTime.Parse(date)
            };

            await _personService.AddAsync(person);
            var personAdded = _personService.Find(person.Id);

            Assert.NotNull(_personService.GetAll());
            Assert.NotNull(personAdded);
            Assert.Equal(1, _personService.GetAll().Count());
            Assert.Equal(name, personAdded.Name);
            Assert.Equal(person.Id, personAdded.Id);
        }

        [Theory]
        [InlineData("Abigail Williams", "1680-07-12")]
        [InlineData("John Hathorne", "1641-08-02")]
        [InlineData("Giles Corey", "1611-09-11")]
        public async Task Persons_Can_Be_Updated(string name, string date)
        {
            var person = new Person
            {
                Name = name,
                Birthday = DateTime.Parse(date)
            };

            await _personService.AddAsync(person);

            person.Name += " (Not a Witch)";

            await _personService.UpdateAsync(person);

            Assert.NotEmpty(_personService.GetAll());
            Assert.NotNull(_personService.Find(1));
            Assert.Equal(1, _personService.GetAll().Count());
            Assert.Equal($"{name} (Not a Witch)", _personService.Find(1).Name);
        }

        [Theory]
        [InlineData("Abigail Williams", "1680-07-12")]
        [InlineData("John Hathorne", "1641-08-02")]
        [InlineData("Giles Corey", "1611-09-11")]
        public async Task Persons_Can_Be_Removed(string name, string date)
        {
            var person = new Person
            {
                Name = name,
                Birthday = DateTime.Parse(date)
            };

            await _personService.AddAsync(person);
            await _personService.RemoveAsync(person.Id);

            Assert.Empty(_personService.GetAll());
            Assert.Null(_personService.Find(1));
            Assert.Equal(0, _personService.GetAll().Count());
        }
    }
}