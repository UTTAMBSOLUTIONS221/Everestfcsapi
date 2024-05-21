using DBL;
using DBL.Models;
using DBL.Models.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public DashboardManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }
        #region System Top Summary Data
        [HttpGet("Getsystemdashboarddata/{TenantId}/{StationId}/{TodayDate}")]
        public async Task<SystemDashboardData> Getsystemdashboarddata(long TenantId,long StationId, string TodayDate)
        {
            return await bl.Getsystemdashboarddata(TenantId, StationId, Convert.ToDateTime(TodayDate));
        }
        #endregion
    }
}
