using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BashMaistoriBG.Contracts
{
    public interface IAdminServices
    {
        IEnumerable<ApplicationUser> GetAllUsers();

        void DeleteUser(string id);

        Task<bool> EditUser(ApplicationUser model);

        UserEditViewModel? PlaceholderUser(string id);

        Task SetUserWorker(string id);

        Task AddSpecialty(Specialty model);

        List<Specialty> GetSpecialties();

        Task<bool> EditSpecialty([FromForm] Specialty model);

        void DeleteSpecialty(int id);
    }
}
