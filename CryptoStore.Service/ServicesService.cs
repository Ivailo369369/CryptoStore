namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ServiceVeiwModel;
    using CryptoStore.ViewModels.ServiceVeiwModel.Edit;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ServicesService : IServicesService   
    {
        private readonly CryptoStoreDb context;

        public ServicesService(CryptoStoreDb context) => this.context = context;

        public async Task CreateAsync(CreateServiceViewModel model) 
        {
            var service = new Service()
            {
                ServiceName = model.ServiceName, 
                ServiceImage = model.ServiceImage, 
                ServiceVideo = model.ServiceVideo,
                Description = model.ServiceDescription,
                ServiceExplain = model.ServiceExplain,
                CryptoTokens = model.Token,
                TotalSum = model.TotalSum
            }; 

            await this.context.AddAsync(service);
            await this.context.SaveChangesAsync();
        }

        public IEnumerable<IndexServiceViewModel> GetAllServices()
            => this.context
            .Services
            .Where(s => s.IsDeleted == false)  
            .Select(s => new IndexServiceViewModel()
            {
                Id = s.Id,
                ServiceName = s.ServiceName,
                ServiceImage = s.ServiceImage,
                ServiceVideo = s.ServiceVideo,
                Description = s.Description,
                CryptoToken = s.CryptoTokens,
                TotalSum = s.TotalSum
            })
            .ToList();

        public async Task<IEnumerable<ServiceDetailsViewModel>> ServiceDetailsAsync(int id)
        => await this.context
            .Services
            .Where(s => s.Id == id)
            .Select(s => new ServiceDetailsViewModel
            {
                Id = s.Id,
                Name = s.ServiceName,
                Description = s.Description,
                ServiceExplain = s.ServiceExplain,
                Image = s.ServiceImage,
                Video = s.ServiceVideo,
                CryptoToken = s.CryptoTokens,
                TotalSum = s.TotalSum
            })
            .ToListAsync();

        public Service GetServiceDetailsForCheckOut() => this.context.Services.FirstOrDefault();

        public async Task<EditingViewModel> PrepareForEditingAsync(int id)
        {
            var service = await this.context.Services.FindAsync(id);

            var model = new EditingViewModel()
            {
                Id = service.Id, 
                Name = service.ServiceName, 
                Description = service.Description,
                ServiceExplain = service.ServiceExplain,
                Image = service.ServiceImage, 
                Video = service.ServiceVideo, 
                CryptoToken = service.CryptoTokens, 
                TotalSum = service.TotalSum
            };

            return model;
        }

        public async Task EditAsync(EditingViewModel model) 
        {
            var service = new Service()
            {
                Id = model.Id, 
                ServiceName = model.Name, 
                Description = model.Description, 
                ServiceExplain = model.ServiceExplain, 
                ServiceImage = model.Image, 
                ServiceVideo = model.Video,
                CryptoTokens = model.CryptoToken, 
                TotalSum = model.TotalSum
            };

            this.context.Services.Update(service);
            await this.context.SaveChangesAsync(); 
        }

        public async Task RemoveAsync(int id)
        { 
            var service = await this.context
                .Services
                .FindAsync(id);

            service.IsDeleted = true;
            await this.context.SaveChangesAsync();
        }
    }
}
