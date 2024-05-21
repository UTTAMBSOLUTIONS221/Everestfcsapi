using DBL.Models.Dashboard;

namespace DBL.Repositories
{
    public interface IDashboardRepository
    {
        SystemDashboardData Getsystemdashboarddata(long TenantId,long StationId, DateTime TodayDate);
    }
}
