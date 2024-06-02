using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BashMaistoriBG.Contracts
{
    public interface IRequestServices
    {
        IEnumerable<RequestListViewModel> Requests();
        IEnumerable<RequestListViewModel> Projects();
        RequestDetailsViewModel? GetRequestById(int id);
        Request PlaceholderRequest(int id);
        Task AddNewRequest([FromForm] RequestAddViewModel model, ApplicationUser user);
        Task<bool> EditRequest([FromForm] RequestEditViewModel model);
        void DeleteRequest(int id);
        Task <List<Specialty>> GetSpecialties();
    }
}
