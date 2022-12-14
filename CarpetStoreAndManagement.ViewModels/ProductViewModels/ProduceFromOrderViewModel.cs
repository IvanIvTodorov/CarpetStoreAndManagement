using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class ProduceFromOrderViewModel : ProduceViewModel
    {
        [Required]
        public int OrderId { get; set; }
    }
}
