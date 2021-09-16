namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.ApiModels.Partner;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.PartnesViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartnerService 
    {
        Task AddPartnersAsync(AddPartnersViewModel model);

        IEnumerable<AllPartnesViewModel> Partnes(); 

        Task<IEnumerable<PartnerRequestModel>> PartnersAsync();  
    }
}
