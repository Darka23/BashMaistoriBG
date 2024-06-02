using BashMaistoriBG.Data.Identity;
using BashMaistoriBG.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BashMaistoriBG.ViewModels;

namespace BashMaistoriBG.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Request>? Requests { get; set; }
        public DbSet<Specialty>? Specialties { get; set; }
        public DbSet<BashMaistoriBG.ViewModels.RequestListViewModel> RequestListViewModel { get; set; }
        public DbSet<BashMaistoriBG.ViewModels.UserEditViewModel> UserEditViewModel { get; set; }
    }
}