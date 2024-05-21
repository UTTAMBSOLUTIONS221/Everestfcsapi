using System.ComponentModel.DataAnnotations;

namespace DBL.Entities
{
    public class StaffForgotPassword
    {
        [Required(ErrorMessage = "Email Address Is Required!")]
        public string? EmailAddress { get; set; }
    }
}
