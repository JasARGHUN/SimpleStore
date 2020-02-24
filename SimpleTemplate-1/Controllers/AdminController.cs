using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTemplate_1.Models;
using SimpleTemplate_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SimpleTemplate_1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IInfoRepository _infoRepository;
        public AdminController(IProductRepository repository, IWebHostEnvironment hostingEnvironment, IInfoRepository infoRepository)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            _infoRepository = infoRepository;
        }
        public ViewResult Index() => View(_repository.Products);

        [HttpGet]
        public async Task<ViewResult> Edit(int ProductID)
        {
            Product product = await _repository.GetProduct(ProductID);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Category = product.Category,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                ExistingPhotoPath = product.Image
            };

            return View(productEditViewModel);
        }

        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _repository.GetProduct(model.ProductID);
                product.Name = model.Name;
                product.Price = model.Price;
                product.ShortDescription = model.ShortDescription;
                product.Description = model.Description;
                product.Category = model.Category;
                if (model.Images != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    product.Image = ProcessUploadFile(model);
                }

                _repository.SaveProduct(product);
                TempData["message"] = $"Object {product.Name} was edited.";
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);
                var newProduct = new Product
                {
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category,
                    Image = uniqueFileName
                };

                _repository.Add(newProduct);
                TempData["message"] = $"{newProduct.Name} has be created";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deleteProduct = _repository.DeleteProduct(productId);
            if(deleteProduct != null)
            {
                TempData["message"] = $"{deleteProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult CreateInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInfo(InfoCreateViewModel model) //НЕИСПОЛЬЗУЕТСЯ!
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadAppImage(model);
                string uniqueSocialFileName = ProcessUploadAppSocialImage(model);
                string uniqueBackgroundImage = ProcessUploadAppBackgroundImage(model);
                string uniqueHomeImage = ProcessUploadAppHomeImage(model);
                string uniqueCarouselImage1 = ProcessUploadFile1(model);
                string uniqueCarouselImage2 = ProcessUploadFile2(model);
                string uniqueCarouselImage3 = ProcessUploadFile3(model);
                var newInfo = new Info
                {
                    AppName = model.AppName,
                    AppAddress = model.AppAddress,
                    AppPhone1 = model.AppPhone1,
                    AppPhone2 = model.AppPhone2,
                    AppSocialAddress = model.AppSocialAddress,
                    AppImage = uniqueFileName,
                    AppSocialImg = uniqueSocialFileName,
                    AppBackgroundImage = uniqueBackgroundImage,
                    AppEmail = model.AppEmail,
                    AppHomeImage = uniqueHomeImage,
                    AppHomeText = model.AppHomeText,
                    CarouselImage = uniqueCarouselImage1,
                    CarouselImage2 = uniqueCarouselImage2,
                    CarouselImage3 = uniqueCarouselImage3,
                    AppHomeText2 = model.AppHomeText2,
                    AppHomeSlideText1 = model.AppHomeSlideText1,
                    AppHomeSlideText2 = model.AppHomeSlideText2,
                    AppHomeSlideText3 = model.AppHomeSlideText3

                };
                _infoRepository.Add(newInfo);
                TempData["message"] = $"{model.AppName} has be created.";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult EditInfo() //получаем текущие данные о приложении(Название, логотип, контакты и тд. приложения).
        {
            Info info = _infoRepository.GetInfo(1);
            InfoEditViewModel infoEditViewModel = new InfoEditViewModel
            {
                Id = info.InfoID,
                AppName = info.AppName, //имя приложения
                AppAddress = info.AppAddress, //адресс(контакты)
                AppPhone1 = info.AppPhone1, //телефон(контакты)
                AppPhone2 = info.AppPhone2, //телефон(контакты)
                AppSocialAddress = info.AppSocialAddress, //ссылка на социальную сеть(контакты)
                ExistingImagePath = info.AppImage, //логотип
                ExistingSocialImagePath = info.AppSocialImg, //социальная ссылка
                ExistingBackgroundImagePath = info.AppBackgroundImage, //задний фон приложения
                AppEmail = info.AppEmail, //почтовый адрес приложения
                ExistingAppHomeImagesPath = info.AppHomeImage, //изображения на главной странице приложения
                AppHomeText = info.AppHomeText, //текст на главной странице приложения
                CarouselPhotoPath1 = info.CarouselImage, //слайд, 1 изображение на главной странице приложения
                CarouselPhotoPath2 = info.CarouselImage2, //слайд, 2 изображение на главной странице приложения
                CarouselPhotoPath3 = info.CarouselImage3, //слайд, 3 изображение на главной странице приложения
                AppHomeText2 = info.AppHomeText2, //заголовок на домашней странице.
                AppHomeSlideText1 = info.AppHomeSlideText1, //текст, описание под 1 слайдом. 
                AppHomeSlideText2 = info.AppHomeSlideText2, //текст, описание под 2 слайдом. 
                AppHomeSlideText3 = info.AppHomeSlideText3 //текст, описание под 3 слайдом. 
            };
            return View(infoEditViewModel);
        }
        [HttpPost]
        public IActionResult EditInfo(InfoEditViewModel model) //отправляем обновленные данные о приложении в Базу Данных(Название, логотип, контакты и тд. приложения).
        {
            if (ModelState.IsValid)
            {
                Info info = _infoRepository.GetInfo(model.Id = 1);
                info.AppName = model.AppName;
                info.AppAddress = model.AppAddress;
                info.AppPhone1 = model.AppPhone1;
                info.AppPhone2 = model.AppPhone2;
                info.AppSocialAddress = model.AppSocialAddress;
                info.AppEmail = model.AppEmail;
                info.AppHomeText = model.AppHomeText;
                info.AppHomeText2 = model.AppHomeText2;
                info.AppHomeSlideText1 = model.AppHomeSlideText1;
                info.AppHomeSlideText2 = model.AppHomeSlideText2;
                info.AppHomeSlideText3 = model.AppHomeSlideText3;

                if (model.AppImages != null) //обновление изображения логотипа сайта.
                {
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    info.AppImage = ProcessUploadAppImage(model);
                }

                if (model.AppSocialImgs != null) //обновление изображение социальной ссылки.
                {
                    if (model.ExistingSocialImagePath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingSocialImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    info.AppSocialImg = ProcessUploadAppSocialImage(model);
                }

                if (model.AppBackgroundImages != null) //обновление изображение заднего фона приложения.
                {
                    if (model.ExistingBackgroundImagePath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingBackgroundImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    info.AppBackgroundImage = ProcessUploadAppBackgroundImage(model);
                }

                if(model.AppHomeImages != null) //обновление изображение начальной страницы приложения.
                {
                    if(model.ExistingAppHomeImagesPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.ExistingAppHomeImagesPath);
                        System.IO.File.Delete(filePath);
                    }
                    info.AppHomeImage = ProcessUploadAppHomeImage(model);
                }
                if (model.CarouselImage1 != null)
                {
                    if (model.CarouselPhotoPath1 != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.CarouselPhotoPath1);
                        System.IO.File.Delete(filePath);
                    }
                    info.CarouselImage = ProcessUploadFile1(model);
                }
                if (model.CarouselImage2 != null)
                {
                    if (model.CarouselPhotoPath2 != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.CarouselPhotoPath2);
                        System.IO.File.Delete(filePath);
                    }
                    info.CarouselImage2 = ProcessUploadFile2(model);
                }
                if (model.CarouselImage3 != null)
                {
                    if (model.CarouselPhotoPath3 != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                            "images", model.CarouselPhotoPath3);
                        System.IO.File.Delete(filePath);
                    }
                    info.CarouselImage3 = ProcessUploadFile3(model);
                }

                _infoRepository.Update(info);
                TempData["message"] = $"Was {model.AppName} was edited.";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Методы отвечающие за получение изображения и загрузкии ее в БД.
        private string ProcessUploadAppImage(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.AppImages != null && model.AppImages.Count > 0)
            {
                foreach (IFormFile photo in model.AppImages)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
        private string ProcessUploadAppSocialImage(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.AppSocialImgs != null && model.AppSocialImgs.Count > 0)
            {
                foreach (IFormFile photo in model.AppSocialImgs)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }

        private string ProcessUploadAppBackgroundImage(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.AppBackgroundImages != null && model.AppBackgroundImages.Count > 0)
            {
                foreach (IFormFile photo in model.AppBackgroundImages)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }

        private string ProcessUploadAppHomeImage(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.AppHomeImages != null && model.AppHomeImages.Count > 0)
            {
                foreach (IFormFile photo in model.AppHomeImages)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }

        private string ProcessUploadFile(ProductCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Images != null && model.Images.Count > 0)
            {
                foreach (IFormFile photo in model.Images)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
        private string ProcessUploadFile1(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.CarouselImage1 != null && model.CarouselImage1.Count > 0)
            {
                foreach (IFormFile photo in model.CarouselImage1)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
        private string ProcessUploadFile2(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.CarouselImage2 != null && model.CarouselImage2.Count > 0)
            {
                foreach (IFormFile photo in model.CarouselImage2)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
        private string ProcessUploadFile3(InfoCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.CarouselImage3 != null && model.CarouselImage3.Count > 0)
            {
                foreach (IFormFile photo in model.CarouselImage3)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
