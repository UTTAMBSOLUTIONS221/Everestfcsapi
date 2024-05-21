namespace DBL.Entities
{
    public class CustomerAccountEmployees
    {
        public long EmployeeId { get; set; }
        public long AccountId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Emailaddress { get; set; }
        public string? Employeeharhcode { get; set; }
        public string? Employeecode { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
