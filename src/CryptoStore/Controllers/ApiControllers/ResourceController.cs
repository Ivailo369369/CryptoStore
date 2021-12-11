namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Resource;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ResourceController :ApiController
    {
        private readonly IResourcesService resource;

        public ResourceController(IResourcesService resource) => this.resource = resource;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ResourceRequestModel>> Resources()
            => await this.resource.GetResourcesAsync(); 
    }
}
