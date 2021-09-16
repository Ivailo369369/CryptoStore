namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Partner;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PartnerController : ApiController
    {
        private readonly IPartnerService partner;

        public PartnerController(IPartnerService partner) => this.partner = partner;

        [HttpGet]
        public async Task<IEnumerable<PartnerRequestModel>> Partners()
            => await this.partner.PartnersAsync(); 
    }
}
