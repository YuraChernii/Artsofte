using Core.Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.DTOs.Employe
{
    public class GetSaleDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}
