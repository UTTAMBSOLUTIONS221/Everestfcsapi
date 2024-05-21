using System.Security;

namespace DBL.Models
{
    public class Systemstaffresponse
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public long Userid { get; set; }
        public long Tenantid { get; set; }
        public long StationId { get; set; }
        public string? Firstname { get; set; }
        public string? Fullname { get; set; }
        public string? Phonenumber { get; set; }
        public string? Username { get; set; }
        public string? Emailaddress { get; set; }
        public string? Passwords { get; set; }
        public string? Passharsh { get; set; }
        public int Loginstatus { get; set; }
        public long Roleid { get; set; }
        public string? Rolename { get; set; }
        public DateTime Lastlogin { get; set; }
        public DateTime Passwordresetdate { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public string? Tenantname { get; set; }
        //public string? Tenantkey { get; set; }
        //public string? Tenantkrapin { get; set; }
        //public string? Tenantemailaddress { get; set; }
        public string? Connectionstring { get; set; }
        public string? Tenantsubdomain { get; set; }
        //public string? Tenantemailkey { get; set; }
        //public string? Tenantemailpassword { get; set; }
        public List<SystemPermissions>? Permission { get; set; }
    }
}
