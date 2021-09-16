﻿namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.ApiModels.Resource;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ResourcesViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IResourcesService 
    {
        Task AddResourcesAsync(CreateResourceViewModel model); 

        IEnumerable<ResourceDetailsViewModel> GetAllResources();

        Task<IEnumerable<ResourceRequestModel>> GetResourcesAsync();
    }
}
