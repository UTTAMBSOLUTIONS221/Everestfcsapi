namespace DBL.Entities
{
    public class SystemTenantAccount
    {
        public long Tenantid { get; set; }
        public long Countryid { get; set; }
        public string? Tenantname { get; set; }
        public string? Tenantsubdomain { get; set; }
        public string? TenantLogo { get; set; }
        public string? TenantEmail { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public string? Passharsh { get; set; }
        public string? Passwords { get; set; }
        public string? TenantReference { get; set; }
        public string? TenantPIN { get; set; }
        public bool IsCCEmail { get; set; }
        public string? CCEmail { get; set; }
        public bool StaffAutoLogOff { get; set; }
        public string? EmailServer { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailPassword { get; set; }
        public string? MessageUrl { get; set; }
        public string? Messageusername { get; set; }
        public string? Messageapikey { get; set; }
        public bool ApplyTax { get; set; }
        public int NoOfDecimalPlaces { get; set; }
        public bool IsEmailEnabled { get; set; }
        public bool IsSmsEnabled { get; set; }
        public bool IsTemplateTrancated { get; set; }
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
        public int Tenantloginstatus { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
