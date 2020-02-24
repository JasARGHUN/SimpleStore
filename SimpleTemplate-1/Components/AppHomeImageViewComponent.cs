using Microsoft.AspNetCore.Mvc;
using SimpleTemplate_1.Models;

namespace SimpleTemplate_1.Components
{
    public class AppHomeImageViewComponent : ViewComponent
    {
        private readonly IInfoRepository _infoRepository;
        public AppHomeImageViewComponent(IInfoRepository infoRepository)
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
