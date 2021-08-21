namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.NewsletterViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewsletterService : INewsletterService
    {
        private readonly CryptoStoreDb context;

        public NewsletterService(CryptoStoreDb context)
            => this.context = context;
        
        public async Task AddAsync(string email)
        {
            var newsletter = new Newsletter()
            {
                Email = email
            }; 

            await this.context.AddAsync(newsletter);
            await this.context.SaveChangesAsync(); 
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
