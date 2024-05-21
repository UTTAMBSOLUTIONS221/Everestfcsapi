namespace DBL.Entities
{
    public class Systemtenantcustomer
    {
        public long CustomerId { get; set; }
        public long DesignationId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Companyname { get; set; }
        public string? Phoneprefix { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public long Createdby { get; set; }
        public  long Modifiedby { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
