using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Entities.Interfaces
{
    public interface IIdentifiable<out T>
    {
        public T Id { get; }
    }
}
