using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public class Info
    {
        public int InfoID { get; set; }

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppName { get; set; } //Название приложения.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppAddress { get; set; } //Адрес организации.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppPhone1 { get; set; } //Первый телефоный номер.

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppPhone2 { get; set; } //Второй телефонный номер.
        public string AppImage { get; set; } //Логотип приложения.
        public string AppSocialImg { get; set; } //Изображения социальной сети.
        public string AppSocialAddress { get; set; } //Ссылка на социальную сеть.
        public string AppBackgroundImage { get; set; } //Заднии фон приложения.

        [EmailAddress(ErrorMessage = "Неправильный формат электронной почты")]
        public string AppEmail { get; set; } //Почтовый адрес приложения.
        public string AppHomeImage { get; set; } //Изображения начальной страницы приложения.
        public string AppHomeText { get; set; } //Текст начальной страницы приложения.
        public string CarouselImage { get; set; } //Изображения слайда - 1 начальной страницы приложения.
        public string CarouselImage2 { get; set; } //Изображения слайда - 2 начальной страницы приложения.
        public string CarouselImage3 { get; set; } //Изображения слайда - 3 начальной страницы приложения.
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppHomeText2 { get; set; } //Текст начальной страницы приложения.
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppHomeSlideText1 { get; set; } //Текст начальной страницы приложения.
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppHomeSlideText2 { get; set; } //Текст начальной страницы приложения.
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string AppHomeSlideText3 { get; set; } //Текст начальной страницы приложения.

    }
}
