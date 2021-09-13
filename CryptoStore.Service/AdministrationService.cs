namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.AdministrationViewModel;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdministrationService : IAdministrationService 
    {
        private readonly CryptoStoreDb context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdministrationService(
            CryptoStoreDb context, 
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IdentityRole PrepareForCreate() => new();
            
        public async Task CreateRoleAsync(IdentityRole model) => await this.roleManager.CreateAsync(model); 
        
        public IEnumerable<UserRolesViewModel> UserRoles()
        => (from user in context
            .Users join userRoles in context
            .UserRoles on user.Id equals userRoles.UserId 
            join role in context.Roles on userRoles.RoleId equals role.Id 
            select new UserRolesViewModel 
            { 
                Id = user.Id, 
                Username = user.UserName, 
                Email = user.Email, 
                EmailConfirmed = user.EmailConfirmed, 
                IsLocked = user.LockoutEnabled,
                RoleName = role.Name 
            })
            .ToList();

        public async Task<IEnumerable<AllPaymentsVeiwModel>> PaymentsAsync()  
            => await this.context
            .Payments
            .Select(p => new AllPaymentsVeiwModel()
            { 
                Username = p.UsernameClient,
                Email = p.Email,
                Phone = p.PhoneNumber,
                ServiceName = p.ServiceName,
                CryptoToken = p.CryptoToken,
                TotalSum = p.TotalSum
            })
            .ToListAsync();

        public async Task BanAsync(string id) 
        {
            var user = await this.userManager.FindByIdAsync(id);
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddDays(14); 
            await this.context.SaveChangesAsync();
        }

        public async Task UnBanAsync(string id) 
        {
            var user = await this.userManager.FindByIdAsync(id);
            user.LockoutEnabled = false; 
            await this.context.SaveChangesAsync();  
        }
    }
}
