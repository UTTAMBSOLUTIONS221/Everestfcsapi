namespace DBL.Models
{
    public class SystemUserRoles
    {
        public long RoleId { get; set; }
        public long TenantId { get; set; }
        public string? Rolename { get; set; }
        public string? Roledescription { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long Createdby { get; set; }
        public string? Createdbyname { get; set; }
        public long Modifiedby { get; set; }
        public string? Modifiedbyname { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<SystemPermissions>? Permissions { get; set; }
    }
}
