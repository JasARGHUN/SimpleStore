using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models.ViewModels
{
    public class InfoCreateViewModel
    {
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppName { get; set; } //Название приложения.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppAddress { get; set; } //Адрес организации.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppPhone1 { get; set; } //Первый телефоный номер.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppPhone2 { get; set; } //Второй телефонный номер.
        public List<IFormFile> AppImages { get; set; } //Логотип приложения.
        public List<IFormFile> AppSocialImgs { get; set; } //Изображения социальной сети.
        public string AppSocialAddress { get; set; } //Ссылка на социальную сеть.
        public List<IFormFile> AppBackgroundImages { get; set; } //Заднии фон приложения.
        public string AppEmail { get; set; } //Почтовый адрес приложения.
        public List<IFormFile> AppHomeImages { get; set; } //Изображения начальной страницы приложения.
        public string AppHomeText { get; set; } //Текст начальной страницы приложения.
        public List<IFormFile> CarouselImage1 { get; set; }
        public List<IFormFile> CarouselImage2 { get; set; }
        public List<IFormFile> CarouselImage3 { get; set; }
        [StringLength(500, ErrorMessage = "Краткое описание не может быть больше 500 символов.")]
        public string AppHomeText2 { get; set; } //Текст начальной страницы приложения.
        [StringLength(300, ErrorMessage = "Краткое описание не может быть больше 300 символов.")]
        public string AppHomeSlideText1 { get; set; } //Текст начальной страницы приложения.
        [StringLength(300, ErrorMessage = "Краткое описание не может быть больше 300 символов.")]
        public string AppHomeSlideText2 { get; set; } //Текст начальной страницы приложения.
        [StringLength(300, ErrorMessage = "Краткое описание не может быть больше 300 символов.")]
        public string AppHomeSlideText3 { get; set; } //Текст начальной страницы приложения.
    }
}
