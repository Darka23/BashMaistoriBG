using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Areas.Worker.Controllers
{
    [Authorize(Roles = ("Worker"))]
    [Area("Worker")]
    public class BaseController : Controller
    {
    }
}
