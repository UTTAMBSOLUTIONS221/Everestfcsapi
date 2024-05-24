namespace DBL.Models
{
    public class CustomermodelResponce
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Token { get; set; }
        public CustomermodeldataResponce? CustomerModel { get; set; }
    }
}
