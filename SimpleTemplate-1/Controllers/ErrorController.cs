using Microsoft.AspNetCore.Mvc;

namespace SimpleTemplate_1.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Данной страницы не существует."; break;
            }
            return View("NotFound");
        }
    }
}
