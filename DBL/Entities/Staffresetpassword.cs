namespace DBL.Entities
{
    public class Staffresetpassword
    {
        public Guid Code { get; set; }
        public long Userid { get; set; }
        public string? Passwords { get; set; }
        public string? Confirmpassword { get; set; }
        public string? Passwordhash { get; set; }
    }
}
