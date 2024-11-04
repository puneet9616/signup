using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotproject.Data.entity
{
    public class productEntity
    {
          [Key]
         public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } 

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; } 

        [Required]
        public string Category { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be zero or greater.")]
        public int Quantity { get; set; } 
        
    }
}