namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.ApiModels.Newsletter;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.NewsletterViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsletterService 
    {
        Task AddAsync(AddUserForNewsletterViewModel model);  

        IEnumerable<NewsletterDetailsViewModel> AllNewsletters();

        Task<Result> AddAsync(NewsletterRequestModel model);
    } 
}
