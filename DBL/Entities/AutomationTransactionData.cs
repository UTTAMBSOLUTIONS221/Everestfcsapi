namespace DBL.Entities
{
    public class AutomationTransactionData
    {
        public string? FtpFolderPath { get; set; }
        public AutomationTransaction? Transaction { get; set; }
        public RFIDCard? RFIDCard { get; set; }
        public Discount? Discount { get; set; }
    }
}
