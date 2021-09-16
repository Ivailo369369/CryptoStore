namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static Infrastructure.WebConstants; 

    public class ServiceController : ApiController
    {
        private readonly IServicesService service;

        public ServiceController(IServicesService service) => this.service = service;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ServiceRequestModel>> Services()
            => await this.service.GetServicesAsync();

        [HttpGet]
        [Route(Id)]
        public async Task<IEnumerable<ServiceDetailsRequestModel>> Details(int id)
            => await this.service.DetailsAsync(id); 
    }
}
