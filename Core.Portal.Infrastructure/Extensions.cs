using Core.Portal.Application.Services.UnitOfWork;
using Core.Portal.Core.Repositories;
using Core.Portal.Infrastructure.Services.Mapping;
using Core.Portal.Infrastructure.Services.UnitOfWork;
using Core.Portal.Infrastructure.SqlServerDatabase.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.Portal.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<IItemRepository>>();
            builder.Services.AddSingleton(typeof(ILogger), logger);

            builder.AddAutomapperProfilers();
        }

        private static void AddAutomapperProfilers(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(SaleProfile), typeof(ExceptionProfile));
        }
    }
}
