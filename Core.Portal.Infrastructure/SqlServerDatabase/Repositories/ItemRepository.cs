using Core.Portal.Core.Entities;
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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<Item> GetByIdAsync(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
