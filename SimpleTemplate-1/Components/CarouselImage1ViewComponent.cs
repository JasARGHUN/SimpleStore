using Microsoft.AspNetCore.Mvc;
using SimpleTemplate_1.Models;

namespace SimpleTemplate_1.Components
{
    public class CarouselImage1ViewComponent : ViewComponent
    {
        private readonly IInfoRepository _infoRepository;
        public CarouselImage1ViewComponent(IInfoRepository infoRepository)
        {
            _infoRepository = infoRepository;
        }
        public IViewComponentResult Invoke()
        {
            var info = _infoRepository.GetInfo(1);
            return View(info);
        }
    }
}
