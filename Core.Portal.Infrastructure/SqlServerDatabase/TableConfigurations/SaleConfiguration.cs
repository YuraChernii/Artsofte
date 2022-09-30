
using Core.Portal.Infrastructure.SqlServerDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Portal.Infrastructure.SqlServerDatabase.TableConfigurations
{
    internal class SaleConfiguration : IEntityTypeConfiguration<SaleTable>
    {
        public void Configure(EntityTypeBuilder<SaleTable> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Item)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ItemId);

            builder.Property(x => x.Price).HasPrecision(14, 2);

        }
    }
}
