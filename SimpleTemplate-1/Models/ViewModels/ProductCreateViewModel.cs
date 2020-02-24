using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SimpleTemplate_1.Models.ViewModels
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Description field can't be empty...")]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
