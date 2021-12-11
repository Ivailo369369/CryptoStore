namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Newsletter;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.NewsletterViewModel;

    public interface INewsletterService : IService
    {
        Task AddAsync(AddUserForNewsletterViewModel model);  

        IEnumerable<NewsletterDetailsViewModel> AllNewsletters();

        Task<Result> AddAsync(NewsletterRequestModel model);
    } 
}
