using Core.Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Core.Entities
{
    public class Sale: AggregateId
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}
