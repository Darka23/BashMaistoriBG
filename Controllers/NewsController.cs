using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Controllers
{
    public class NewsController : BaseController
    {
        public IActionResult News()
        {
            return View();
        }
    }
}
