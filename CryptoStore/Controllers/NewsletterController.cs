namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using CryptoStore.ViewModels.BidingViewModels;

    using static Infrastructure.WebConstants;

    public class NewsletterController : Controller
    {
        private readonly INewsletterService newsletter;

        public NewsletterController(INewsletterService newsletter) => this.newsletter = newsletter;

        [Authorize] 
        [HttpGet] 
        public IActionResult AddUserForNewsletter() => this.View();

        [Authorize]
        [HttpPost] 
        public async Task<IActionResult> AddUserForNewsletter(AddUserForNewsletterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            }

            await this.newsletter.AddAsync(model);  

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "You subscribre for us!"
            }); 
             
            return RedirectToAction("Index", "Home"); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public IActionResult GetAllNewsletters()  
        {
            var model = this.newsletter.AllNewsletters(); 

            return this.View(model); 
        }
    }
}
