using DBL.Entities;
using DBL.Repositories;

namespace DBL.Models
{
    public class SystemGadgetResponseModel
    {
        public long GadgetId { get; set; }
        public string? GadgetName { get; set; }
        public string? Descriptions { get; set; }
        public string? Imei1 { get; set; }
        public string? Imei12 { get; set; }
        public string? Serialnumber { get; set; }
        public long StationId { get; set; }
        public string? Stationname { get; set; }
        public string? ClientApiEndpointUrl { get; set; }
        public List<SystemStaffModel>? Staffs { get; set; }
    }
}
