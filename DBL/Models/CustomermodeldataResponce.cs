namespace DBL.Models
{
    public class CustomermodeldataResponce
    {
        public long CustomerId { get; set; }
        public long Tenantid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Companyname { get; set; }
        public string? Emailaddress { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? Designation { get; set; }
        public string? Pin { get; set; }
        public string? Pinharsh { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? CompanyIncorporationDate { get; set; }
        public string? CompanyRegistrationNo { get; set; }
        public string? CompanyPIN { get; set; }
        public string? CompanyVAT { get; set; }
        public DateTime? Contractstartdate { get; set; }
        public DateTime? Contractenddate { get; set; }
        public long StationId { get; set; }
        public long CountryId { get; set; }
        public long NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public long ConsecutiveTransTimeMin { get; set; }
        public bool IsPortaluser { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
