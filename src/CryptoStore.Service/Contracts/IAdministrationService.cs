namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.AdministrationViewModel;

    public interface IAdministrationService : IService
    {
        IdentityRole PrepareForCreate();

        Task CreateRoleAsync(IdentityRole model); 

        IEnumerable<UserRolesViewModel> UserRoles();

        Task<IEnumerable<AllPaymentsVeiwModel>> PaymentsAsync();

        Task BanAsync(string userId);

        Task UnBanAsync(string id);  
    }
}
