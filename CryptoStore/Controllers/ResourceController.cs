namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.Validation;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks; 

    public class ResourceController : Controller
    {
        private readonly IResourcesService resourcesServiceAsync;

        public ResourceController(IResourcesService resourcesServiceAsync)
            => this.resourcesServiceAsync = resourcesServiceAsync;

        [HttpGet]
        [Authorize(Roles = AdministrationValidation.Admin)]
        [Authorize(Policy = AdministrationValidation.WritePolicy)]
        public IActionResult Create()    
            => this.View();

        [HttpPost]
        [Authorize(Roles = AdministrationValidation.Admin)]
        [Authorize(Policy = AdministrationValidation.WritePolicy)] 
        public async Task<IActionResult> Create(CreateResourceViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.resourcesServiceAsync.AddResourcesAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfully added resource!" 
            });

            return RedirectToAction("Index", "Resource");    
        } 

        [Authorize] 
        public IActionResult Index()
        {
            var model = this.resourcesServiceAsync.GetAllResources();
            return this.View(model);  
        }
    }
}
