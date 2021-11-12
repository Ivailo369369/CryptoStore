namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Resource;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ResourcesViewModel;

    public interface IResourcesService : IService
    {
        Task AddResourcesAsync(CreateResourceViewModel model); 

        IEnumerable<ResourceDetailsViewModel> GetAllResources();

        Task<IEnumerable<ResourceRequestModel>> GetResourcesAsync();
    }
}
