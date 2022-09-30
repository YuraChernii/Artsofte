using Core.Portal.Application.Services.UnitOfWork;
using Core.Portal.Core.Repositories;
using Core.Portal.Infrastructure.SqlServerDatabase.Contexts;
using Microsoft.Extensions.Logging;

namespace Core.Portal.Infrastructure.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IItemRepository ItemRepository { get; private set; }

        public ISaleRepository SaleRepository { get; private set; }


        public UnitOfWork(
            ApplicationDbContext context,
            IItemRepository itemRepository,
            ISaleRepository saleRepository,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;

            ItemRepository = itemRepository;
            SaleRepository = saleRepository;

            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
