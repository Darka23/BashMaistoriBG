using BashMaistoriBG.Contracts;
using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.Data.Repositories;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BashMaistoriBG.Services
{
    public class RequestServices : IRequestServices
    {
        private IApplicationDbRepository repo;
        private ICloudinaryService cloudinaryService;

        public RequestServices(IApplicationDbRepository _repo, ICloudinaryService _cloudinaryService)
        {
            repo = _repo;
            cloudinaryService = _cloudinaryService;
        }

        public async Task AddNewRequest([FromForm] RequestAddViewModel model, ApplicationUser user)
        {
            var existing = repo.All<Request>()
                .Where(r => r.Name == model.Name)
                .FirstOrDefault();

            if (existing != null)
            {
                throw new ArgumentException("Request already exist");
            }

            string imageUrl = cloudinaryService.Image(model.Image, "BashMaistoriBG");


            await repo.AddAsync(new Request()
            {
                Budget = model.Budget,
                ImageUrl = imageUrl,
                Description = model.Description,
                Name = model.Name,
                SpecialtyId = model.SpecialtyId,
                StartDate = DateTime.Now,
                Status = "Assigned",
                RequestorId = user.Id,
                Requestor = user

            });

            await repo.SaveChangesAsync();
        }

        public IEnumerable<RequestListViewModel> Requests()
        {
            return repo.All<Request>()
                .Where(x=>x.Status != "Finished")
                 .Select(x => new RequestListViewModel()
                 {
                     Id = x.Id,
                     SpecialistType = x.Specialty.Name,
                     ImageUrl = x.ImageUrl,
                     Name = x.Name,
                     Description = x.Description,
                     StartDate = x.StartDate,
                     Budget = x.Budget
                 });
                 
        }

        public IEnumerable<RequestListViewModel> Projects()
        {
            return repo.All<Request>()
                 .Where(x => x.Status == "Finished")
                 .Select(x => new RequestListViewModel()
                 {
                     Id = x.Id,
                     SpecialistType = x.Specialty.Name,
                     ImageUrl = x.ImageUrl,
                     Description = x.Description,
                     Name = x.Name,
                     StartDate = x.StartDate,
                     Budget = x.Budget
                 });

        }

        public RequestDetailsViewModel? GetRequestById(int id)
        {
            return repo.All<Request>()
                .Where(r => r.Id == id)
                .Select(r => new RequestDetailsViewModel()
                {
                    Id = id,
                    Name = r.Name,
                    ImageUrl = r.ImageUrl,
                    Budget = r.Budget,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    SpecialtyId = r.SpecialtyId,
                    SpecialistType = r.Specialty.Name,
                    Description = r.Description,
                    RequestorName = r.Requestor.UserName,
                    Status = r.Status,
                })
                .FirstOrDefault();
        }

        public async Task<bool> EditRequest([FromForm]RequestEditViewModel model)
        {
            bool result = false;
            var request = await repo.GetByIdAsync<Request>(model.Id);

            var imageUrl = cloudinaryService.Image(model.Image, "BashMaistoriBG");

            if (request != null)
            {
                request.Name = model.Name;
                request.Description = model.Description;
                request.Budget = model.Budget;
                request.SpecialtyId = model.SpecialtyId;
                request.ImageUrl = imageUrl;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public Request PlaceholderRequest(int id)
        {

            return repo.All<Request>()
                .Where(x => x.Id == id)
                .Select(x => new Request()
                {
                    SpecialtyId = x.SpecialtyId,
                    Budget = x.Budget,
                    StartDate = x.StartDate,
                    Description = x.Description,
                    Name = x.Name,
                    
                })
                .First();
        }

        public void DeleteRequest(int id)
        {
            var request = repo.All<Request>()
                .Where(r=>r.Id==id)
                .First();

            repo.Delete(request);

            repo.SaveChanges();
        }

        public async Task <List<Specialty>> GetSpecialties()
        {
            return await repo.All<Specialty>().ToListAsync();
        }
    }
}
