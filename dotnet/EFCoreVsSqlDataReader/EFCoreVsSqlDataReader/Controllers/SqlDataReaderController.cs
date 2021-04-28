using EFCoreVsSqlDataReader.Data;
using EFCoreVsSqlDataReader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SqlDataReaderController : ControllerBase
    {
        private readonly ISqlDataReaderContext _sqlDbContext;

        public SqlDataReaderController(ISqlDataReaderContext context)
        {
            this._sqlDbContext = context;
        }

        [HttpGet("GetTopRecords")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTopRecords()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._sqlDbContext.GetTopRecordsAsync();
            return new OkObjectResult(response);
        }

        [HttpGet("GetEvenRecords")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEvenRecords()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._sqlDbContext.GetEvenRecordsAsync();
            return new OkObjectResult(response);
        }

        [HttpGet("GetComplexWhere")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComplexWhere()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._sqlDbContext.GetComplexWhereAsync();
            return new OkObjectResult(response);
        }
    }
}
