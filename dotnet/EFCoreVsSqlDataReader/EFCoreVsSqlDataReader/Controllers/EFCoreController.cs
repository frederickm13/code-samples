using EFCoreVsSqlDataReader.Data;
using EFCoreVsSqlDataReader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreVsSqlDataReader.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EFCoreController : ControllerBase
    {
        private readonly IEFContext _efDbContext;

        public EFCoreController(IEFContext context)
        {
            this._efDbContext = context;
        }

        [HttpGet("GetTopRecords")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTopRecords()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._efDbContext.GetTopRecordsAsync();
            return new OkObjectResult(response);
        }

        [HttpGet("GetEvenRecords")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEvenRecords()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._efDbContext.GetEvenRecordsAsync();
            return new OkObjectResult(response);
        }

        [HttpGet("GetComplexWhere")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComplexWhere()
        {
            ApiResponse response = new ApiResponse();
            response.Records = await this._efDbContext.GetComplexWhereAsync();
            return new OkObjectResult(response);
        }
    }
}
