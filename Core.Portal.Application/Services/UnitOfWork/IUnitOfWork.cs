using Core.Portal.Core.Repositories;

namespace Core.Portal.Application.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISaleRepository SaleRepository { get; }
        public IItemRepository ItemRepository { get; }

        public Task CompleteAsync();
    }
}
