﻿using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
