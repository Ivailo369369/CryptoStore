namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static Validation.AdministrationValidation;

    public class NewsletterController : Controller
    {
        private readonly INewsletterService service; 

        public NewsletterController(INewsletterService service) => this.service = service; 

        [Authorize] 
        [HttpGet] 
        public IActionResult AddUserForNewsletter() => this.View();

        [Authorize]
        [HttpPost] 
        public async Task<IActionResult> AddUserForNewsletter(string email)
        {

            if (!ModelState.IsValid)
            {
                return this.View(); 
            }

            await this.service.AddAsync(email); 

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
            var model = this.service.AllNewsletters();
            return this.View(model); 
        }
    }
}
