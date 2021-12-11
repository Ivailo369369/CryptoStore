namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.WebConstants; 

    public class PartnerController : Controller
    {
        private readonly IPartnerService parther;

        public PartnerController(IPartnerService partner) => this.parther = partner;

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

            this.parther.AddPartnersAsync(model);

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
            var model = this.parther.Partnes(); 

            return this.View(model); 
        }
    } 
}
