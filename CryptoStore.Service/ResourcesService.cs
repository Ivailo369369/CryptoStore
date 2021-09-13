namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ResourcesViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ResourcesService : IResourcesService
    {
        private readonly CryptoStoreDb context;

        public ResourcesService(CryptoStoreDb context) => this.context = context;

        public async Task AddResourcesAsync(CreateResourceViewModel model)
        {
            var resource = new Resource()
            {
                Name = model.Name,
                Image = model.Image, 
                Description = model.Description,
                Hyperlink = model.Hyperlink
            }; 

            await this.context.AddAsync(resource);
            await this.context.SaveChangesAsync();
        }

        public IEnumerable<ResourceDetailsViewModel> GetAllResources()
            => this.context
            .Resources
            .Select(r => new ResourceDetailsViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                Image = r.Image,
                Description = r.Description,
                Hyperlink = r.Hyperlink
            })
            .ToList();
    }
}
