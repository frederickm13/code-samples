using EFCoreVsSqlDataReader.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVsSqlDataReader.Data
{
    public class EFDbContext : DbContext
    {
        public DbSet<ExampleModel> ExampleRecords { get; set; }
        public DbSet<TimingLog> TimingLogs { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }
    }
}
