namespace DBL.Entities
{
    public class AccountCardReplaceDetails
    {
        public long AccountId { get; set; }
        public long MaskType { get; set; }
        public long? CardId { get; set; }
        public long? MaskId { get; set; }
        public string? MaskSno { get; set; }
        public string? Pin { get; set; }
        public string? Pinharsh { get; set; }
        public long? Createdby { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
