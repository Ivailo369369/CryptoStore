namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Validation.AdministrationValidation; 

    public class PartnerController : Controller
    {
        private readonly IPartnerService service;

        public PartnerController(IPartnerService service) => this.service = service; 

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View(); 

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public IActionResult Add(AddPartnersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            this.service.AddPartnersAsync(model);

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
            var model = this.service.Partnes();
            return this.View(model); 
        }
    } 
}
