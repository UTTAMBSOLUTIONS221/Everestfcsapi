namespace DBL.Entities
{
    public class CustomerAccountTopup
    {
        public long AccountId { get; set; }
        public long TenantId { get; set; }
        public long PaymentModeId { get; set; }
        public decimal TopupAmount { get; set; }
        public DateTime TopupDatecreated { get; set; }
        public string? TopupReference { get; set; }
        public string? TransactionDescription { get; set; }
        public string? TransactionReference { get; set; }
        public string? AutomationReference { get; set; }
        public string? TopupErpReference { get; set; }
        public string? AccounTopupChequenumbert { get; set; }
        public string? TopupBankAccount { get; set; }
        public string? TopupDrawerBank { get; set; }
        public string? TopupPayeeBank { get; set; }
        public string? TopupBranchDeposited { get; set; }
        public string? TopupDepostiSlip { get; set; }
        public long StationId { get; set; }
        public long StaffId { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
