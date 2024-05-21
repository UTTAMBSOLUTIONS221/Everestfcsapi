namespace DBL.Entities
{
    public class SystemStaffs
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
    }
}
