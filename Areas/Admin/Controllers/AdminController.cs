using BashMaistoriBG.Contracts;
using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BashMaistoriBG.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private IAdminServices adminServices;
        public AdminController(IAdminServices _adminServices)
        {
            adminServices = _adminServices;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult UsersList()
        {
            var users = adminServices.GetAllUsers();
            
            return View(users);
        }
        public IActionResult DeleteUser(string id)
        {
            adminServices.DeleteUser(id);

            return RedirectToAction("UsersList", "Admin");
        }
        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var currUser = adminServices.PlaceholderUser(id);
            ViewData["SpecialtyId"] = new SelectList(adminServices.GetSpecialties(), "Id", "Name");
            return View(currUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser model)
        {
            if (await adminServices.EditUser(model))
            {
                return RedirectToAction("UsersList", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<IActionResult> SetUserAsWorker(string id)
        {
            await adminServices.SetUserWorker(id);

            return RedirectToAction("UsersList", "Admin");
        }

        [HttpGet]
        public IActionResult AddSpecialty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecialty(Specialty model)
        {
            await adminServices.AddSpecialty(model);

            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult ListSpecialties()
        {
            var model = adminServices.GetSpecialties();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditSpecialty(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditSpecialty([FromForm] Specialty model)
        { 
            if (await adminServices.EditSpecialty(model))
            {
                return RedirectToAction("AdminPanel", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        } 

        public IActionResult DeleteSpecialty(int id)
        {
            adminServices.DeleteSpecialty(id);
            return RedirectToAction("AdminPanel", "Admin");
        }

        
    }
}
