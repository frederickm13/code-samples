using EFCoreVsSqlDataReader.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Data
{
    public interface IExampleContext
    {
        public Task<List<ExampleModel>> GetTopRecordsAsync();

        public Task<List<ExampleModel>> GetEvenRecordsAsync();

        public Task<List<ExampleModel>> GetComplexWhereAsync();
    }
}
