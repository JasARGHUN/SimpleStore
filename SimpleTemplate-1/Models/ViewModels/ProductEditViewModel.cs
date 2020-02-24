using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models.ViewModels
{
    public class ProductEditViewModel : ProductCreateViewModel
    {
        public int ProductID { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
