using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.FeedbackViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [MinLength(1)]
        public string Email { get; set; }
        [Required]
        [MaxLength(2500)]
        [MinLength(1)]
        public string Message { get; set; }

    }
}
