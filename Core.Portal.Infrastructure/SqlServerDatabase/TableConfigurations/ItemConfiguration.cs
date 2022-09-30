
using Core.Portal.Infrastructure.SqlServerDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Portal.Infrastructure.SqlServerDatabase.TableConfigurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<ItemTable>
    {
        public void Configure(EntityTypeBuilder<ItemTable> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
