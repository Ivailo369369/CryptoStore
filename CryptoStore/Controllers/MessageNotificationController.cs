namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MessageNotificationController : Controller
    {
        private readonly IMessageNotificationService messageNotification;
        private readonly ICurrentUserService currentUser;  

        public MessageNotificationController(
            IMessageNotificationService messageNotification,
            ICurrentUserService currentUser)
        {
            this.messageNotification = messageNotification;
            this.currentUser = currentUser;
        }

        [Authorize] 
        [HttpGet]
        public IActionResult Create()
        {
            var username = this.currentUser.GetUsername();

            var model = new CreateMessageViewModel
            {
                Username = username,           
            };

            return this.View(model); 
        }

        [Authorize]
        [HttpPost] 
        public async Task<IActionResult> Create(CreateMessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.messageNotification.CreateMessageAsyc(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your message was sent successfully. We will contact you!"
            }); 

            return RedirectToAction("Index", "Home"); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public IActionResult Notifications()
        {
            var model = this.messageNotification.Notification();

            return this.View(model); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> DetailsNotification(int id)
        {
            var model = await this.messageNotification.DetailsAsync(id);

            return this.View(model);
        }

        [Authorize(Roles = AdministrationValidation.Admin)]
        [Authorize(Policy = AdministrationValidation.WritePolicy)]
        [HttpGet("Id")] 
        public async Task<IActionResult> Clear(int id) 
        {
            await this.messageNotification.ClearAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfull!" 
            });

            return RedirectToAction("Notifications"); 
        }
    }
}
