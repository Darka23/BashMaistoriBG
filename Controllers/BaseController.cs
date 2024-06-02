using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
