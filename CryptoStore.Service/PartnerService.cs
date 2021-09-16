﻿namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Partner;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.PartnesViewModel;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PartnerService : IPartnerService
    {
        private readonly CryptoStoreDb context;

        public PartnerService(CryptoStoreDb context) => this.context = context; 

        public async Task AddPartnersAsync(AddPartnersViewModel model)
        {
            var partner = new Partner()
            {
                CompanyName = model.CompanyName,
                Description = model.Description,
                LogoCompany = model.LogoCompany,
                WebsiteLink = model.WebsiteLink,
                Financing = model.Financing
            }; 

            await this.context.Partners.AddAsync(partner);
            await this.context.SaveChangesAsync(); 
        }

        public IEnumerable<AllPartnesViewModel> Partnes()
            => this.context
            .Partners
            .Select(p => new AllPartnesViewModel()
            { 
                Id = p.Id, 
                CompanyName = p.CompanyName, 
                Description = p.Description, 
                Logo = p.LogoCompany, 
                Website = p.WebsiteLink
            })
            .ToList();

        public async Task<IEnumerable<PartnerRequestModel>> PartnersAsync()
           => await this.context
            .Partners
            .Select(p => new PartnerRequestModel()
            {
                Id = p.Id, 
                CompanyName = p.CompanyName,
                Description = p.Description,
                Logo = p.LogoCompany,
                Website = p.WebsiteLink
            })
            .ToListAsync();
    }
}
