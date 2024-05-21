using DBL.Entities;

namespace DBL.Models
{
    public class SystemStaffsDataModel
    {
        public long Userid { get; set; }
        public long Tenantid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public string? Username { get; set; }
        public string? Emailaddress { get; set; }
        public long Roleid { get; set; }
        public string? Passharsh { get; set; }
        public string? Passwords { get; set; }
        public long LimitTypeId { get; set; }
        public decimal LimitTypeValue { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Loginstatus { get; set; }
        public DateTime Passwordresetdate { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Lastlogin { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public bool HasPortalAccess { get; set; }
        public List<SystemStations>? SystemStation { get; set; }
        public string? Tenantname { get; set; }
        public string? Tenantsubdomain { get; set; }
        public string? TenantLogo { get; set; }
        public string? TenantEmail { get; set; }
        public string? TenantReference { get; set; }
        public string? TenantPIN { get; set; }
        public bool IsCCEmail { get; set; }
        public string? CCEmail { get; set; }
        public bool StaffAutoLogOff { get; set; }
        public string? EmailServer { get; set; }
        public string? EmailServerEmail { get; set; }
        public string? EmailPassword { get; set; }
        public string? MessageUrl { get; set; }
        public string? Messageusername { get; set; }
        public string? Messageapikey { get; set; }
        public bool ApplyTax { get; set; }
        public int NoOfDecimalPlaces { get; set; }
        public bool IsEmailEnabled { get; set; }
        public bool IsSmsEnabled { get; set; }
        public bool IsTemplateTruncated { get; set; }
    }
}
