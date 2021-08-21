namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.AdministrationViewModel;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdministrationService
    {
        IdentityRole PrepareForCreate();

        Task CreateRoleAsync(IdentityRole model); 

        IEnumerable<UserRolesViewModel> UserRoles();

        Task<IEnumerable<AllPaymentsVeiwModel>> PaymentsAsync();

        Task BanAsync(string userId);

        Task UnBanAsync(string id);  
    }
}
