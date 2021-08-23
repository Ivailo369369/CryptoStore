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

    using static Validation.AdministrationValidation;

    public class MessageNotificationController : Controller
    {
        private readonly IMessageNotificationService messageNotificationService;
        private readonly ICurrentUserService currentUserService; 

        public MessageNotificationController(IMessageNotificationService messageNotificationService,
            ICurrentUserService currentUserService)
        {
            this.messageNotificationService = messageNotificationService;
            this.currentUserService = currentUserService;
        }

        [Authorize] 
        [HttpGet]
        public IActionResult Create()
        {
            var username = this.currentUserService.GetUsername();
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

            await this.messageNotificationService.CreateMessageAsyc(model);

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
            var model = this.messageNotificationService.Notification();
            return this.View(model); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> DetailsNotification(int id)
        {
            var model = await this.messageNotificationService.DetailsAsync(id);
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet("Id")] 
        public async Task<IActionResult> Clear(int id) 
        {
            await this.messageNotificationService.ClearAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfull!" 
            });

            return RedirectToAction("Notifications"); 
        }
    }
}
