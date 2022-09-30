using Core.Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Core.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<Item> GetByIdAsync(int itemId);
    }
}
