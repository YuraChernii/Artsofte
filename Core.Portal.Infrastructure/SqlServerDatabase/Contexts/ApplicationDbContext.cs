
using Core.Portal.Infrastructure.SqlServerDatabase.Entities;
using Core.Portal.Infrastructure.SqlServerDatabase.SeedingData;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.SeedData();
        }
        internal DbSet<SaleTable> Sales { get; set; }
        internal DbSet<ItemTable> Items { get; set; }
    }
}