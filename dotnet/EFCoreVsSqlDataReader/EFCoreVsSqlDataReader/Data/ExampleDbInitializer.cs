using EFCoreVsSqlDataReader.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreVsSqlDataReader.Data
{
    public static class ExampleDbInitializer
    {
        public static void Initialize(IConfiguration config, EFDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any example records.
            if (context.ExampleRecords.Any())
            {
                return; // DB has been seeded
            }

            int numRecords = int.Parse(config["NumberOfRecords"]);

            for (int i = 0; i < numRecords; i++)
            {
                ExampleModel record = new ExampleModel()
                {
                    TextValue = $"This is some sample text: {i}",
                    BoolValue = i % 2 == 0,
                    DecimalValue = i * 12345
                };

                context.ExampleRecords.Add(record);
            }
            
            context.SaveChanges();
        }
    }
}
