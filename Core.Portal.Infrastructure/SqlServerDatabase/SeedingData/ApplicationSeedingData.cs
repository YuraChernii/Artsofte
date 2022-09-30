using Core.Portal.Infrastructure.SqlServerDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Portal.Infrastructure.SqlServerDatabase.SeedingData
{
    internal static class ApplicationSeedingData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProgrammingLanguageTable>()
            //    .HasData(
            //    new ProgrammingLanguageTable { Id = 1, Name = "python"},
            //    new ProgrammingLanguageTable { Id = 2, Name = "java"},
            //    new ProgrammingLanguageTable { Id = 3, Name = ".net" },
            //    new ProgrammingLanguageTable { Id = 4, Name = "scala" },
            //    new ProgrammingLanguageTable { Id = 5, Name = "js" },
            //    new ProgrammingLanguageTable { Id = 6, Name = "ruby" },
            //    new ProgrammingLanguageTable { Id = 7, Name = "c++" }
            //    );
            //modelBuilder.Entity<ItemTable>()
            //    .HasData(
            //    new ItemTable { Id = Guid.NewGuid(), Name = "Department 1" },
            //    new ItemTable { Id = Guid.NewGuid(), Name = "Department 2" }
            //    );
        }
    }
}
