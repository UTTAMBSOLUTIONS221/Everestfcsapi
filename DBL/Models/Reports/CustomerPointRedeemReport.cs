namespace DBL.Models.Reports
{
    public class CustomerPointRedeemReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? StationName { get; set; }
        public string? AccountName { get; set; }
        public string? AttendantName { get; set; }
        public List<CustomerPointRedeem>? CustomerPointRedeem { get; set; }
    }
    public class CustomerPointRedeem
    {

        public DateTime TransactionDate { get; set; }
        public string? Customer { get; set; }
        public string? IDNumber { get; set; }
        public long AccountNumber { get; set; }
        public double RedeemedAmount { get; set; }
        public string? AccountCreditType { get; set; }
        public double RedeemedValue { get; set; }
        public string? Station { get; set; }
        public string? Attendant { get; set; }
    }

}


