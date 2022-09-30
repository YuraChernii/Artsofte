using Core.Portal.Application.DTOs.Employe;
using Core.Portal.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Application.Queries.Employe.GetEmployes
{
    public class GetSales: IRequest<GetSalesDTO> 
    {
        public string Name { get; set; }
        public MarketStatus Status { get; set; }
        public SortOrderType SortOrder { get; set; }
        public SaleSortKey SortKey { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
