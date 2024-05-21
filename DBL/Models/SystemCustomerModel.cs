namespace DBL.Models
{
    public class SystemCustomerModel
    {
        public long CustomerId { get; set; }
        public string? Designation { get; set; }
        public string? Customername { get; set; }
        public string? Emailaddress { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Companyname { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? Pin { get; set; }
        public string? Pinharsh { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime CompanyIncorporationDate { get; set; }
        public string? CompanyRegistrationNo { get; set; }
        public string? CompanyPIN { get; set; }
        public string? CompanyVAT { get; set; }
        public DateTime Contractstartdate { get; set; }
        public DateTime Contractenddate { get; set; }
        public long StationId { get; set; }
        public long CountryId { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public bool IsPortaluser { get; set; }
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
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public string? CustomerRegStation { get; set; }
        public string? CountryName { get; set; }
        public string? CustomerCreatedBy { get; set; }
        public string? CustomerModofiedBy { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }

    }
}
