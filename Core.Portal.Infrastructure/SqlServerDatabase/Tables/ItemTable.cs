using Core.Portal.Infrastructure.SqlServerDatabase.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Entities
{
    public class ItemTable: IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
        public IEnumerable<SaleTable> Sales { get; set; }
    }
}
