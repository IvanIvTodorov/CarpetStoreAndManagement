using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models
{
    public class Loom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]

        public string? ImgUrl { get; set; }
        [Required]

        public DateTime ExpirуDate { get; set; }
    }
}
