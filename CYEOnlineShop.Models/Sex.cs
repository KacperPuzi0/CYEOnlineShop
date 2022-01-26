using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYEOnlineShop.Models
{
    public class Sex
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sex")]
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
