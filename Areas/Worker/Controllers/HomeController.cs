using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Areas.Worker.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
