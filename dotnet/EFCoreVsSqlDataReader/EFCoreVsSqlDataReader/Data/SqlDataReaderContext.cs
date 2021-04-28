using EFCoreVsSqlDataReader.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Data
{
    public class SqlDataReaderContext : IDisposable, ISqlDataReaderContext
    {
        private SqlConnection _sqlConnection;
        private IEFContext _efContext;

        public SqlDataReaderContext(IConfiguration config, IEFContext efContext)
        {
            this._efContext = efContext;
            this._sqlConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            this._sqlConnection.Open();
        }

        public async Task<List<ExampleModel>> GetTopRecordsAsync()
        {
            const string query = "SELECT TOP(5000) * FROM [ExampleRecords];";

            Stopwatch sw = Stopwatch.StartNew();
            var result = await this.ExecuteSelectQuery(query);
            sw.Stop();
            await _efContext.CreateTimingLogAsync("SqlDataReader", "Query1", sw.Elapsed.Milliseconds);

            return result;
        }

        public async Task<List<ExampleModel>> GetEvenRecordsAsync()
        {
            const string query = "SELECT TOP(5000) * FROM [ExampleRecords] WHERE [DecimalValue] % 2 = 0;";

            Stopwatch sw = Stopwatch.StartNew();
            var result = await this.ExecuteSelectQuery(query);
            sw.Stop();
            await _efContext.CreateTimingLogAsync("SqlDataReader", "Query2", sw.Elapsed.Milliseconds);

            return result;
        }

        public async Task<List<ExampleModel>> GetComplexWhereAsync()
        {
            const string query = "SELECT TOP(5000) * FROM [ExampleRecords] WHERE [BoolValue] = 1 AND [TextValue] LIKE '%2%'";

            Stopwatch sw = Stopwatch.StartNew();
            var result = await this.ExecuteSelectQuery(query);
            sw.Stop();
            await _efContext.CreateTimingLogAsync("SqlDataReader", "Query3", sw.Elapsed.Milliseconds);

            return result;
        }

        private async Task<List<ExampleModel>> ExecuteSelectQuery(string query)
        {
            List<ExampleModel> returnResult = new List<ExampleModel>();

            using (SqlCommand cmd = new SqlCommand(query, this._sqlConnection))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    ExampleModel record = new ExampleModel()
                    {
                        ID = (int)reader.GetValue(reader.GetOrdinal("ID")),
                        TextValue = (string)reader.GetValue(reader.GetOrdinal("TextValue")),
                        BoolValue = (bool)reader.GetValue(reader.GetOrdinal("BoolValue")),
                        DecimalValue = (decimal)reader.GetValue(reader.GetOrdinal("DecimalValue")),
                    };

                    returnResult.Add(record);
                }
            }

            return returnResult;
        }

        public async void Dispose()
        {
            await _sqlConnection.DisposeAsync();
        }
    }
}
