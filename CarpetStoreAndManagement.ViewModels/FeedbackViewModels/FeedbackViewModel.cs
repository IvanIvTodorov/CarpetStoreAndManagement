using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.FeedbackViewModels
{
    public class FeedbackViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 1)]
        public string Message { get; set; }

    }
}
