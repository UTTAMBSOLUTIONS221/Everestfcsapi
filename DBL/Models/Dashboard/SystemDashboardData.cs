namespace DBL.Models.Dashboard
{
    public class SystemDashboardData
    {
        public int Systemstaffs { get; set; }
        public int Prepaidcustomer { get; set; }
        public int Postpaidcustomer { get; set; }
        public int OnlineSales { get; set; }
        public int OfflineSales { get; set; }
        public int AwardedPoints { get; set; }
        public int RedeemedPoints { get; set; }
        public List<DailySalesData>? DailySales { get; set; }
        public List<MonthlySalesData>? MonthlySales { get; set; }
        public List<DailyAwardsData>? DailyAwards { get; set; }
        public List<MonthlyAwardsData>? MonthlyAwards { get; set; }

    }
    public class DailySalesData
    {
        public string? StationName { get; set; }
        public decimal OnlineSaleAmount { get; set; }
        public decimal OfflineSaleAmount { get; set; }
    }

    public class MonthlySalesData
    {
        public string? StationName { get; set; }
        public decimal OnlineSaleAmount { get; set; }
        public decimal OfflineSaleAmount { get; set; }
    }

    public class DailyAwardsData
    {
        public string? StationName { get; set; }
        public decimal PointAwardAmount { get; set; }
        public decimal PointRedeemAmount { get; set; }
    }

    public class MonthlyAwardsData
    {
        public string? StationName { get; set; }
        public decimal PointAwardAmount { get; set; }
        public decimal PointRedeemAmount { get; set; }
    }
}
