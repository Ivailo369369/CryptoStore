namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.ServiceVeiwModel.Edit;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static Infrastructure.WebConstants;

    public class ServiceController : Controller
    {
        private readonly IServicesService serviceAsync;

        public ServiceController(IServicesService service) => this.service = service;

        [Authorize(Roles = Admin)] 
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Create() => this.View(); 

        [Authorize(Roles = Admin)] 
        [Authorize(Policy = WritePolicy)] 
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceViewModel model)   
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            }

            await this.service.CreateAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The service was created successfully" 
            });

            return RedirectToAction("GetAllServices", "Service");  
        } 

        public IActionResult GetAllServices()
        {  
            var model = this.serviceAsync.GetAllServices();
            return this.View(model); 
        } 

        [Authorize] 
        public async Task<IActionResult> ServiceDetails(int id)
        {
            var model = await this.serviceAsync.ServiceDetailsAsync(id); 
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]  
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.serviceAsync.PrepareForEditingAsync(id);
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            await this.service.EditAsync(model); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfull editing!" 
            });

            return RedirectToAction("GetAllServices", "Service"); 
        } 

        public async Task<IActionResult> Remove(int id)
        {
            await this.service.RemoveAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The service is deleted!" 
            });

            return RedirectToAction("GetAllServices");
        }
    }
}
