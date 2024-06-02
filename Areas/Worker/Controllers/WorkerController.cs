using BashMaistoriBG.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Areas.Worker.Controllers
{
    public class WorkerController : BaseController
    {
        private IWorkerServices workerServices;
        public WorkerController(IWorkerServices _workerServices)
        {
            workerServices = _workerServices;
        }
        public async Task<IActionResult> AcceptRequest(int id)
        {
            await workerServices.AcceptRequest(id);

            return RedirectToAction("Requests", "Request", new {area = ""});
        }
        public async Task<IActionResult> FinishRequest(int id)
        {
            await workerServices.FinishRequest(id);

            return RedirectToAction("Requests", "Request", new { area = "" });
        }
    }
}
