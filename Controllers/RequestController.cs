using BashMaistoriBG.Contracts;
using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BashMaistoriBG.Controllers
{
    public class RequestController : BaseController
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestServices requestServices;
        private readonly UserManager<ApplicationUser> userManager;

        public RequestController(ILogger<RequestController> logger, 
            IRequestServices _requestServices, 
            UserManager<ApplicationUser> _userManager)
        {
            _logger = logger;
            requestServices = _requestServices;
            userManager = _userManager;
        }
        public IActionResult Requests(string requestDesc, string specialtyName, string sortOrder)
        {
            var model = requestServices.Requests().AsQueryable();

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["BudgetSortParam"] = sortOrder == "budget" ? "budget_desc" : "budget";

            model = sortOrder switch
            {
                "desc" => model.OrderByDescending(x => x.Name),
                "date" => model.OrderBy(x => x.StartDate),
                "date_desc" => model.OrderByDescending(x => x.StartDate),
                "budget" => model.OrderBy(x => x.Budget),
                "budget_desc" => model.OrderByDescending(x => x.Budget),
                _ => model.OrderBy(x => x.Name)
            };

            if (!string.IsNullOrEmpty(requestDesc))
            {
                model = model.Where(x => x.Description.Contains(requestDesc));
            }
            if (!string.IsNullOrEmpty(specialtyName))
            {
                model = model.Where(x => x.SpecialistType == specialtyName);
            }
            return View(model.ToList());
        }

        public async Task<IActionResult> RequestDetails(int id)
        {
            var request = requestServices.GetRequestById(id);
            var currUser = await userManager.GetUserAsync(HttpContext.User);

            var model = new
            {
                Request = request,
                CurrUser = currUser,
            };

            return View(model);
        }

        public IActionResult Projects(string requestName, string sortOrder)
        {
            var model = requestServices.Projects().AsQueryable();

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["BudgetSortParam"] = sortOrder == "budget" ? "budget_desc" : "budget";

            model = sortOrder switch
            {
                "desc" => model.OrderByDescending(x => x.Name),
                "date" => model.OrderBy(x => x.StartDate),
                "date_desc" => model.OrderByDescending(x => x.StartDate),
                "budget" => model.OrderBy(x => x.Budget),
                "budget_desc" => model.OrderByDescending(x => x.Budget),
                _ => model.OrderBy(x => x.Name)
            };

            if (!string.IsNullOrEmpty(requestName))
            {
                model = model.Where(x => x.Name.Contains(requestName));
            }
            return View(model.ToList());
        }
        public IActionResult ProjectDetails(int id)
        {
            var model = requestServices.GetRequestById(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeRequest()
        {
            ViewData["SpecialtyId"] = new SelectList(await requestServices.GetSpecialties(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeRequest(RequestAddViewModel model)
        {  
            var currUser = await userManager.GetUserAsync(HttpContext.User);

            await requestServices.AddNewRequest(model, currUser);

            return RedirectToAction("Requests", "Request");
        }


        [HttpGet]
        public async Task<IActionResult> EditRequest(int id)
        {          
            var placeholder = requestServices.PlaceholderRequest(id);

            var model = new RequestEditViewModel()
            {
                Budget  = placeholder.Budget,
                Description = placeholder.Description,
                Id = id,
                Name = placeholder.Name,
                Specialty = placeholder.Specialty,
                SpecialtyId = placeholder.SpecialtyId,
            };

            ViewData["SpecialtyId"] = new SelectList(await requestServices.GetSpecialties(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(RequestEditViewModel model)
        {
            if (await requestServices.EditRequest(model))
            {
                return RedirectToAction("Requests", "Request");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult DeleteRequest(int id)
        {
            requestServices.DeleteRequest(id);

            return RedirectToAction("Requests", "Request");
        }
    }
}
