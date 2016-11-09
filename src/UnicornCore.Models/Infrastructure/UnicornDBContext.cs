using Microsoft.EntityFrameworkCore;
using UnicornCore.Models.DatabaseEntity;

namespace UnicornCore.Models.Infrastructure
{
    public class UnicornDBContext : DbContext
    {
        public UnicornDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}