using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class ProduceFromOrderViewModel : ProduceViewModel
    {
        [Required]
        public int OrderId { get; set; }
    }
}
