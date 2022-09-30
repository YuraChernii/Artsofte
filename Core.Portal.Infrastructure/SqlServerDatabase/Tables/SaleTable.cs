using Core.Portal.Core.Enums;
using Core.Portal.Infrastructure.SqlServerDatabase.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Entities
{
    public class SaleTable : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public ItemTable Item { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}
