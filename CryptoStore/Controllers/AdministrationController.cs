namespace CryptoStore.Controllers 
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    [Authorize(Roles = Admin)]  
    [Authorize(Policy = WritePolicy)] 
    public class AdministrationController : Controller 
    {
        private readonly IAdministrationService administrationService;
        public AdministrationController(IAdministrationService administrationServiceAsync)
            => this.administrationService = administrationServiceAsync;

        [HttpGet]
        public IActionResult Create()
        {
            var model = this.administrationService.PrepareForCreate();
            return this.View(model); 
        } 

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model) 
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            await  this.administrationService.CreateRoleAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfully added role!"
            });

            return RedirectToAction("GetAllRoles", "Administration");
        }

        public IActionResult UserWithRoles()
        {
            var model = this.administrationService.UserRoles(); 
            return this.View(model);
        }

        public async Task<IActionResult> Payments()
        {
            var model = await this.administrationService.PaymentsAsync();
            return this.View(model); 
        }
         
        public async Task<IActionResult> Ban(string id) 
        {
            await this.administrationService.BanAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Danger,
                Message = "This account is LockOut!"
            }); 

            return RedirectToAction("UserWithRoles"); 
        }

        public async Task<IActionResult> UnBan(string id)
        {
            await this.administrationService.UnBanAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success, 
                Message = "Тhis account is unlocked!"
            }); 

            return RedirectToAction("UserWithRoles");
        } 
    }
}
