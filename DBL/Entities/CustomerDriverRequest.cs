namespace DBL.Entities
{
    public class CustomerDriverRequest
    {
        public long CustomerId { get; set; }
        public long AccountId { get; set; }
        public string? SecretCode { get; set; }
        public string? HashKey { get; set; }
        public string? DriverCustomer { get; set; }
    }
}
