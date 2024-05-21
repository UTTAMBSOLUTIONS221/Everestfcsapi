namespace DBL.Models
{
    public class SingleFinanceTransactions
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Currencyname { get; set; }
        public long Tenantid { get; set; }
        public string? TransactionCode { get; set; }
        public string? TransactionRefenece { get; set; }
        public string? Saledescription { get; set; }
        public string? Customername { get; set; }
        public string? Emailaddress { get; set; }
        public string? CustomerCard { get; set; }
        public string? CardCode { get; set; }
        public string? Agreementtypename { get; set; }
        public string? StationName { get; set; }
        public long StaffId { get; set; }
        public string? Attendantname { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FuelProCard { get; set; }
        public decimal CustomerBalance { get; set; }
        public decimal CardBalance { get; set; }
        public decimal CumulativePoints { get; set; }
        public decimal CurrentPoints { get; set; }
        public string? RewardName { get; set; }
        public string? Groupingname { get; set; }
        public string? SaleRefence { get; set; }
        public string? Paymentmode { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Ticketlines>? Ticketlines { get; set; }
    }
    public class Ticketlines
    {
        public string? Productvariationname { get; set; }
        public decimal Price { get; set; }
        public decimal Units { get; set; }
        public decimal Discount { get; set; }
        public decimal SaleAmount { get; set; }
    }
}
