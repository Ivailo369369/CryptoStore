namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static Infrastructure.WebConstants;

    public class ResourceController : Controller
    {
        private readonly IResourcesService resource;

        public ResourceController(IResourcesService resource) => this.resource = resource;

        [HttpGet]
        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)] 
        public async Task<IActionResult> Create(CreateResourceViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.resource.AddResourcesAsync(model);

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
            var model = this.resource.GetAllResources(); 

            return this.View(model);  
        }
    }
}
