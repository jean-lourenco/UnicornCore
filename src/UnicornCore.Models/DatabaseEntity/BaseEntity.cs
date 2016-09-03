using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornCore.Models.Interfaces;

namespace UnicornCore.Models.DatabaseEntity
{
    public class BaseEntity : IEntity
    {
        public long Id { get; set; }
    }
}
