namespace DBL.Entities
{
    public class CustomerAgreementAccountData
    {
        public long AccountId { get; set; }
        public long AgreementId { get; set; }
        public long AccountNumber { get; set; }
        public long MaskType { get; set; }
        public long? MaskId { get; set; }
        public string? MaskSno { get; set; }
        public long GroupingId { get; set; }
        public long ParentId { get; set; }
        public long CredittypeId { get; set; }
        public long LimitTypeId { get; set; }
        public decimal ConsumptionLimit { get; set; }
        public string? ConsumptionPeriod { get; set; }
        public string? EquipmentReg { get; set; }
        public string? CreateAccountType { get; set; }
        public string? Pin { get; set; }
        public string? Pinharsh { get; set; }
        public long VehicleMakeId { get; set; }
        public long VehicleModelId { get; set; }
        public long ProductVariationId { get; set; }
        public decimal TankCapacity { get; set; }
        public decimal OdometerReading { get; set; }
        public bool Isadminactive { get; set; }
        public bool Iscustomeractive { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
    //public class CustomerAgreementAccountData
    //{
    //    public long CustomerAgreementId { get; set; }
    //    public long LoyaltyGroupingId { get; set; }
    //    public long CreditTypeId { get; set; }
    //    public string? EquipmentNumber { get; set; }
    //    public long EquipmentMakeId { get; set; }
    //    public long EquipmentModelId { get; set; }
    //    public decimal EquipmentTankCapacity { get; set; }
    //    public string? Fullname { get; set; }
    //    public string? EmailAddress { get; set; }
    //    public string? PhoneNumber { get; set; }
    //    public long ProductVariationId { get; set; }
    //    public double Productlimitvalue { get; set; }
    //    public string? ProductlimitPeriod { get; set; }
    //    public long ProductLimitTypeId { get; set; }
    //    public List<long>? AccountStationId { get; set; }
    //    public List<string>? AccountWeekdays { get; set; }
    //    public string? AccountWeekdaysStartTime { get; set; }
    //    public string? AccountWeekdaysEndTime { get; set; }
    //    public string? Pin { get; set; }
    //    public string? Pinharsh { get; set; }
    //    public int AccountFrequency { get; set; }
    //    public string? AccountFrequencyPeriod { get; set; }
    //    public long CreatedbyId { get; set; }
    //    public string? Createdby { get; set; }
    //    public long ModifiedbyId { get; set; }
    //    public string? Modifiedby { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public DateTime DateModified { get; set; }
    //}
}
