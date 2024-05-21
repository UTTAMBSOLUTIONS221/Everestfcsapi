using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    public class DiscountListData
    {
        public long DiscountListId { get; set; }
        public string? DiscountListname { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<DiscountListValue>? Discountlistvalues { get; set; }
    }

    public class DiscountListValue
    {
        public long LnkDiscountProductId { get; set; }
        public long StationId { get; set; }
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? Daysapplicable { get; set; }
        public string? Starttime { get; set; }
        public string? Endtime { get; set; }
        public string? Station { get; set; }
        public decimal Discountvalue { get; set; }
    }
}
