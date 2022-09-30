using Core.Portal.Core.Entities;
using Core.Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Core.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        public Task<Sale> GetByIdAsync(int saleId);
        public Task<Sale> GetByIdWithItemAsync(int saleId);

        public Task<List<Sale>> GetListAsync(
            string name,
            MarketStatus status,
            SortOrderType sortOrder = SortOrderType.desc,
            SaleSortKey sortKey = SaleSortKey.Price,
            int limit = 10,
            int page = 0
            );
    }
}
