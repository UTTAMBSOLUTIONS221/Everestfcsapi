namespace DBL.Models
{
    public class CustomerAgreementPayments
    {
        public long CustomerPaymentId { get; set; }
        public long AgreementId { get; set; }
        public long PaymentModeId { get; set; }
        public long FinanceTransactionId { get; set; }
        public string? TransactionCode { get; set; }

        public string? Saledescription { get; set; }
        public bool Isreversed { get; set; }
        public string? SaleReference { get; set; }
        public DateTime ActualDate { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionReference { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPaymentValidated { get; set; }
        public string? ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string? Memo { get; set; }
        public string? DrawerBank { get; set; }
        public string? DepositBank { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string? PaidBy { get; set; }
        public string? SlipReference { get; set; }
        public string? Provider { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
