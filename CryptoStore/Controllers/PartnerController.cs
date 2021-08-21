namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.Validation;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PartnerController : Controller
    {
        private readonly IPartnerService partnerService;

        public PartnerController(IPartnerService partnerService)
            => this.partnerService = partnerService;

        [Authorize(Roles = AdministrationValidation.Admin)]
        [Authorize(Policy = AdministrationValidation.WritePolicy)]
        [HttpGet]
        public IActionResult Add()
            => this.View(); 

        [Authorize(Roles = AdministrationValidation.Admin)]
        [Authorize(Policy = AdministrationValidation.WritePolicy)]
        [HttpPost]
        public IActionResult Add(AddPartnersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            this.partnerService.AddPartnersAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfully added partner!"
            }); 

            return RedirectToAction("GetPartnes", "Partner");  
        }

        [Authorize]
        public IActionResult GetPartnes()
        {
            var model = this.partnerService.Partnes();
            return this.View(model); 
        }
    } 
}
