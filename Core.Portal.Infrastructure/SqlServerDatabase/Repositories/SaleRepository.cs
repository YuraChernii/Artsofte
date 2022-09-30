using Core.Portal.Application.Exceptions;
using Core.Portal.Core.Entities;
using Core.Portal.Core.Enums;
using Core.Portal.Core.Repositories;
using Core.Portal.Infrastructure.SqlServerDatabase.Contexts;
using Core.Portal.Infrastructure.SqlServerDatabase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<Sale> GetByIdAsync(int saleId)
        {
            var sale = await _context.Sales.Where(_ => _.Id == saleId).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new BadRequestException("Sale does not exist.");
            }

            return sale.AsEntity();
        }

        public async Task<Sale> GetByIdWithItemAsync(int saleId)
        {
            var sale = await _context.Sales.Where(_ => _.Id == saleId).Include(_ => _.Item).FirstOrDefaultAsync();

            if (sale == null)
            {
                throw new BadRequestException("Sale does not exist.");
            }

            return sale.AsEntity();
        }

        public async Task<List<Sale>> GetListAsync(
            string name,
            MarketStatus status,
            SortOrderType sortOrder = SortOrderType.desc,
            SaleSortKey sortKey = SaleSortKey.Price,
            int limit = 10,
            int page = 0
            )
        {
            //Get list of ids of items that contain searching name
            var itemIds = _context.Items
                .Where(_ => _.Name.Contains(name))
                .Select(_ => _.Id);

            var sales = _context.Sales
                .Where(_ => itemIds.Contains(_.ItemId))
                .Where(_ => _.Status == status);

            if (sortKey == SaleSortKey.Price && sortOrder == SortOrderType.asc)
            {
                sales = sales.OrderBy(_ => _.Price);
            }
            else if (sortKey == SaleSortKey.Price && sortOrder == SortOrderType.desc)
            {
                sales = sales.OrderByDescending(_ => _.Price);
            }
            else if (sortKey == SaleSortKey.CreatedDt && sortOrder == SortOrderType.desc)
            {
                sales = sales.OrderByDescending(_ => _.CreatedDt);
            }
            else
            {
                sales = sales.OrderBy(_ => _.CreatedDt);
            }

            sales = sales.Skip(limit * page).Take(limit);

            var salesQueryResult = await sales.Include(_ => _.Item).ToListAsync();

            var salesReturnResult = new List<Sale>();
            foreach (var item in salesQueryResult)
            {
                salesReturnResult.Add(item.AsEntity());
            }

            return salesReturnResult;
        }
    }
}
