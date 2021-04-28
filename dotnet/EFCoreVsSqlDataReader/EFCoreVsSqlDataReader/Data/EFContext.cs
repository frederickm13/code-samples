using EFCoreVsSqlDataReader.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Data
{
    public class EFContext : IEFContext
    {
        private EFDbContext _efDbContext;

        public EFContext(EFDbContext context)
        {
            this._efDbContext = context;
        }

        public async Task<List<ExampleModel>> GetTopRecordsAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = await this._efDbContext.ExampleRecords.Take(5000).ToListAsync();
            sw.Stop();
            await this.CreateTimingLogAsync("EFCore", "Query1", sw.Elapsed.Milliseconds);

            return result;
        }

        public async Task<List<ExampleModel>> GetEvenRecordsAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = await this._efDbContext.ExampleRecords
                .Where(record => record.DecimalValue % 2 == 0)
                .Take(5000)
                .ToListAsync();
            sw.Stop();
            await this.CreateTimingLogAsync("EFCore", "Query2", sw.Elapsed.Milliseconds);

            return result;
        }

        public async Task<List<ExampleModel>> GetComplexWhereAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = await this._efDbContext.ExampleRecords
                .Where(record => record.BoolValue == true
                    && record.TextValue.Contains("2"))
                .Take(5000)
                .ToListAsync();
            sw.Stop();
            await this.CreateTimingLogAsync("EFCore", "Query3", sw.Elapsed.Milliseconds);

            return result;
        }

        public async Task<bool> CreateTimingLogAsync(string context, string query, int ms)
        {
            TimingLog log = new TimingLog()
            {
                CreatedOn = DateTime.Now,
                Context = context,
                Query = query,
                MilliSeconds = ms
            };

            await this._efDbContext.TimingLogs.AddAsync(log);
            await this._efDbContext.SaveChangesAsync();
            return true;
        }
    }
}
