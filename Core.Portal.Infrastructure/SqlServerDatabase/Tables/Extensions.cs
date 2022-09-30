using Core.Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Portal.Infrastructure.SqlServerDatabase.Entities
{
    public static class Extensions
    {
        public static Item AsEntity(this ItemTable itemTable) =>
            new Item()
            {
                Id = itemTable.Id,
                Name = itemTable.Name,
                Description = itemTable.Description,
                Metadata = itemTable.Metadata,
            };
        public static ItemTable AsTable(this Item item) =>
            new ItemTable()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Metadata = item.Metadata,
            };
        public static Sale AsEntity(this SaleTable saleTable) =>
            new Sale()
            {
                Id = saleTable.Id,
                ItemId = saleTable.ItemId,
                CreatedDt = saleTable.CreatedDt,
                FinishedDt = saleTable.FinishedDt,
                Price = saleTable.Price,
                Status = saleTable.Status,
                Seller = saleTable.Seller,
                Buyer = saleTable.Buyer,
            };

        public static SaleTable AsTable(this Sale sale) =>
            new SaleTable()
            {
                Id = sale.Id,
                ItemId = sale.ItemId,
                CreatedDt = sale.CreatedDt,
                FinishedDt = sale.FinishedDt,
                Price = sale.Price,
                Status = sale.Status,
                Seller = sale.Seller,
                Buyer = sale.Buyer,
            };
    }
}
