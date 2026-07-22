using System.ComponentModel.DataAnnotations;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Models
{
    public class ErrorViewModel
    {

        [Display(Name = "Request ID")]
        public string? RequestId { get; set; }

        [Display(Name = "Show Request ID")]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Example validation/annotations added for demonstration.
        // These attributes are harmless for the Error view but illustrate how to add DataAnnotations
        // to other models where validation is required.
        [Display(Name = "User Email")]
        [EmailAddress(ErrorMessage = "The email address is not valid.")]
        public string? UserEmail { get; set; }

        [Display(Name = "Error Code")]
        [RegularExpression(@"^[A-Z0-9_-]{3,20}$", ErrorMessage = "Error code must be 3-20 chars, uppercase letters, digits, '_' or '-'.")]
        public string? ErrorCode { get; set; }
    }
}

