namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.NewsletterViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsletterService 
    {
        Task AddAsync(string email);  

        IEnumerable<NewsletterDetailsViewModel> AllNewsletters(); 
    } 
}
