using BashMaistoriBG.Contracts;
using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.Data.Repositories;
using BashMaistoriBG.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BashMaistoriBG.Services
{
    public class AdminServices : IAdminServices
    {
        private IApplicationDbRepository repo;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AdminServices(IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            repo = _repo;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return repo.All<ApplicationUser>().Include(x=>x.Specialty).ToList();
        }

        public void DeleteUser(string id)
        {
            var user = repo.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .First();

            if (user != null)
            {
                repo.Delete<ApplicationUser>(user);
                repo.SaveChanges();
            }
        }

        public async Task<bool> EditUser(ApplicationUser model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);


            if (user != null)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.SpecialtyId = model.SpecialtyId;
                user.Specialty = model.Specialty;
                user.PhoneNumber = model.PhoneNumber;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public UserEditViewModel? PlaceholderUser(string id)
        {
            return repo.All<ApplicationUser>()
                .Where(r => r.Id == id)
                .Select(r => new UserEditViewModel()
                {
                    Id = id,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    SpecialtyId = r.SpecialtyId,
                    PhoneNumber = r.PhoneNumber,
                    UserName = r.UserName
                })
                .FirstOrDefault();
        }

        public async Task SetUserWorker(string id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.AddToRoleAsync(user, "Worker");
            
            var repoUser = await repo.GetByIdAsync<ApplicationUser>(id.ToString());
            repoUser.Role = "Worker";

            await repo.SaveChangesAsync();
        }

        public async Task AddSpecialty(Specialty model)
        {
            var existing = repo.All<Specialty>()
                .Where(r => r.Name == model.Name)
                .FirstOrDefault();

            if (existing != null)
            {
                throw new ArgumentException("Specialty already exist");
            }
            await repo.AddAsync(new Specialty()
            {
                Name = model.Name
            });

            await repo.SaveChangesAsync();
        }

        public List<Specialty> GetSpecialties()
        {
            return repo.All<Specialty>().ToList();
        }

        public async Task<bool> EditSpecialty([FromForm] Specialty model)
        {
            bool result = false;
            var specialty = await repo.GetByIdAsync<Specialty>(model.Id);

            if (specialty != null)
            {
                specialty.Name = model.Name;

                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public void DeleteSpecialty(int id)
        {
            var specialty = repo.All<Specialty>()
                .Where(x=>x.Id == id)
                .First();

            repo.Delete(specialty);

            repo.SaveChanges();
        }
    }
}
