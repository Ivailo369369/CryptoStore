namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Partner;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.PartnesViewModel;

    public interface IPartnerService : IService
    {
        Task AddPartnersAsync(AddPartnersViewModel model);

        IEnumerable<AllPartnesViewModel> Partnes(); 

        Task<IEnumerable<PartnerRequestModel>> PartnersAsync();  
    }
}
