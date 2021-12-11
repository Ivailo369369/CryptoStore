namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CryptoStore.Data.Models;
    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Service;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ServiceVeiwModel;
    using CryptoStore.ViewModels.ServiceVeiwModel.Edit;


    public interface IServicesService : IService
    {
        Task CreateAsync(CreateServiceViewModel model); 

        IEnumerable<IndexServiceViewModel> GetAllServices();

        Task<IEnumerable<ServiceDetailsViewModel>> ServiceDetailsAsync(int id); 

        Service GetServiceDetailsForCheckOut();

        Task<EditingViewModel> PrepareForEditingAsync(int id);

        Task EditAsync(EditingViewModel model);

        Task RemoveAsync(int id);

        Task<IEnumerable<ServiceRequestModel>> GetServicesAsync();

        Task<IEnumerable<ServiceDetailsRequestModel>> DetailsAsync(int id); 
    }
}
