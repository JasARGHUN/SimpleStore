using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Short description field can't be empty...")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Description field can't be empty...")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
