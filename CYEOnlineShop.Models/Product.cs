using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int Designer { get; set; }

        public string Description { get; set; }
        [Required]

        public string Composition { get; set; }
        [Required]
        public string Size { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1,10000)]
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        public int SexId { get; set; }
        [ValidateNever]
        public Sex Sex { get; set; }
    }
}
