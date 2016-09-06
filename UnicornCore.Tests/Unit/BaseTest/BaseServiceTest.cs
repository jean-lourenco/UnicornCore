using Autofac;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DBContext;
using UnicornCore.Models.Interfaces;
using UnicornCore.Services;

namespace UnicornCore.Tests.Unit.BaseTest
{
    public class BaseServiceTest
    {
        public IContainer Container { get; set; }

        public BaseServiceTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof(InMemoryContext<>)).As(typeof(IDBContext<>));

            builder.RegisterType<PersonService>().As<IPersonService>();

            Container = builder.Build();
        }
    }
}