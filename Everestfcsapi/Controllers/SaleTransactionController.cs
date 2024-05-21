using DBL;
using DBL.Entities;
using DBL.Models;
using Everestfcsapi.Helpers;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleTransactionController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public SaleTransactionController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }
 
        [HttpPost("PostSaleTransactionData")]
        public async Task<SingleFinanceTransactions> PostSaleTransactionData(SalesTransactionRequest obj)
        {
            return await bl.PostSaleTransaction(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("PostReverseSaleTransactionData")]
        public async Task<Genericmodel> PostReverseSaleTransactionData(ReverseSaleRequestData obj)
        {
            return await bl.PostReverseSaleTransactionData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getallofflinesalesdata/{TenantId}")]
        public async Task<IEnumerable<FinanceTransactions>> Getallofflinesalesdata(long TenantId)
        {
            return await bl.Getallofflinesalesdata(TenantId);
        }
        [HttpGet("Getsingleofflinesalesdata/{FinanceTransactionId}/{AccountId}")]
        public async Task<SingleFinanceTransactions> Getsingleofflinesalesdata(long FinanceTransactionId, long AccountId)
        {
            return await bl.Getsingleofflinesalesdata(FinanceTransactionId, AccountId);
        }
    }
}
