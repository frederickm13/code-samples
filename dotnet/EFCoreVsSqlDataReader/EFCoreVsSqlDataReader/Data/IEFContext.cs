using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Data
{
    public interface IEFContext : IExampleContext
    {
        public Task<bool> CreateTimingLogAsync(string context, string query, int ms);
    }
}
