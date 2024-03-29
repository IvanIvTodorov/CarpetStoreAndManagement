﻿using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(400)]
        public string Message { get; set; } = null!;
    }
}
