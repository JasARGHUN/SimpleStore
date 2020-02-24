using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models.ViewModels
{
    public class InfoEditViewModel : InfoCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingImagePath { get; set; }
        public string ExistingSocialImagePath { get; set; }
        public string ExistingBackgroundImagePath { get; set; }
        public string ExistingAppHomeImagesPath { get; set; }
        public string CarouselPhotoPath1 { get; set; }
        public string CarouselPhotoPath2 { get; set; }
        public string CarouselPhotoPath3 { get; set; }
    }
}
