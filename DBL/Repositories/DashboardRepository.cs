using Dapper;
using DBL.Models;
using DBL.Models.Dashboard;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class DashboardRepository : BaseRepository, IDashboardRepository
    {
        public DashboardRepository(string connectionString) : base(connectionString)
        {
        }
        public SystemDashboardData Getsystemdashboarddata(long TenantId,long StationId, DateTime TodayDate)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@TodayDate", TodayDate);
                parameters.Add("@DashboardDetailsData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemDashboardDetailData", parameters, commandType: CommandType.StoredProcedure);
                string SalesTransactionDetailData = parameters.Get<string>("@DashboardDetailsData");
                return JsonConvert.DeserializeObject<SystemDashboardData>(SalesTransactionDetailData);
            }
        }
    }
}
