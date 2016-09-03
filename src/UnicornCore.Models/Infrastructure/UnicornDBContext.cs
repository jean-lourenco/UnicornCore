using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Models.DatabaseEntity;

namespace UnicornCore.Models.Infrastructure
{
    public class UnicornDBContext : DbContext
    {
        public UnicornDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
