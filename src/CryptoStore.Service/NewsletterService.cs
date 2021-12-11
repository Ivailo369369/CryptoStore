namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Newsletter;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.NewsletterViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewsletterService : INewsletterService
    {
        private readonly CryptoStoreDb context;

        public NewsletterService(CryptoStoreDb context) => this.context = context;
        
        public async Task AddAsync(AddUserForNewsletterViewModel model)
        {
            var newsletter = new Newsletter()
            {
                Email = model.Email
            }; 

            await this.context.AddAsync(newsletter);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<Result> AddAsync(NewsletterRequestModel model)
        {
            var newsletter = new Newsletter()
            {
                Email = model.Email
            };

            if (newsletter == null)
            {
                return "You can't subscrubre for this newsletter.";
            }

            await this.context.AddAsync(newsletter);
            await this.context.SaveChangesAsync();

            return true;
        }

        public IEnumerable<NewsletterDetailsViewModel> AllNewsletters()
            => this.context
            .Newsletters
            .Select(n => new NewsletterDetailsViewModel()
            {
                Email = n.Email
            })
            .ToList();
    }
}
