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
    public class Clth
    {
        public int Id { get; set; }

        [Required]
        public string Designer { get; set; }

        public string Description { get; set; }
        [Required]

        public string Composition { get; set; }
        [Required]
        public string Size { get; set; }

        [Required]
        public string IsAvailable { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category Category { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public int SexId { get; set; }
        [ForeignKey("SexId")]
        public Sex Sex { get; set; }
    }
}

