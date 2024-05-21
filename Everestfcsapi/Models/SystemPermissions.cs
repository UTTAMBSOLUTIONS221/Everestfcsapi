namespace Everestfcsapi.Models
{
    public class SystemPermissions
    {
        public long PermissionId { get; set; }
        public string? Permissionname { get; set; }
        public string? Permissiondescription { get; set; }
        public long ParentId { get; set; }
        public long OrderLevel { get; set; }
        public bool Isportal { get; set; }
    }
}
